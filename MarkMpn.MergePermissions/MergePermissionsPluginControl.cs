using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using XrmToolBox.Extensibility;

namespace MarkMpn.MergePermissions
{
    public partial class MergePermissionsPluginControl : PluginControlBase
    {
        private PrivilegeDepth _depth = PrivilegeDepth.Global;
        private PrivilegeDepth _relatedDepth = PrivilegeDepth.Global;

        class Role
        {
            public Role(Entity entity)
            {
                EntityReference = entity.ToEntityReference();
                EntityReference.Name = entity.GetAttributeValue<string>("name");
            }

            public EntityReference EntityReference { get; }

            public override string ToString() => EntityReference.Name;
        }

        public MergePermissionsPluginControl()
        {
            InitializeComponent();
        }

        class LoadResult
        {
            public string[] Entities { get; set; }

            public Role[] Roles { get; set; }
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            entityListBox.Items.Clear();
            roleListBox.Items.Clear();

            if (newService == null)
                return;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading...",
                Work = (worker, args) =>
                {
                    var result = new LoadResult();

                    // Get the list of mergeable entities
                    var entities =
                        new[]
                        {
                            "account",
                            "lead",
                            "contact",
                            "incident"
                        }
                        .Where(e => EntityExists(e))
                        .ToList();

                    if (EntityExists("data8_entitymergeconfiguration"))
                    {
                        var qry = new QueryExpression("data8_entitymergeconfiguration");
                        qry.ColumnSet = new ColumnSet("data8_name");
                        qry.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                        entities = entities
                            .Concat(Service.RetrieveMultiple(qry).Entities.Select(e => e.GetAttributeValue<string>("data8_name")))
                            .Distinct()
                            .ToList();
                    }

                    entities.Sort();
                    result.Entities = entities.ToArray();

                    // Get the available security roles
                    var roleQry = new QueryExpression("role");
                    roleQry.Criteria.AddCondition("iscustomizable", ConditionOperator.Equal, true);
                    roleQry.Criteria.AddCondition("parentroleid", ConditionOperator.Null);
                    roleQry.ColumnSet = new ColumnSet("name");

                    result.Roles = Service.RetrieveMultiple(roleQry)
                        .Entities
                        .Select(e => new Role(e))
                        .OrderBy(r => r.ToString())
                        .ToArray();

                    args.Result = result;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var result = (LoadResult)args.Result;

                    entityListBox.Items.AddRange(result.Entities);
                    roleListBox.Items.AddRange(result.Roles);
                }
            });
        }

        private bool EntityExists(string logicalName)
        {
            var qry = new RetrieveMetadataChangesRequest
            {
                Query = new EntityQueryExpression
                {
                    Criteria = new MetadataFilterExpression
                    {
                        Conditions =
                        {
                            new MetadataConditionExpression(nameof(EntityMetadata.LogicalName), MetadataConditionOperator.Equals, logicalName)
                        }
                    },
                    Properties = new MetadataPropertiesExpression
                    {
                        PropertyNames =
                        {
                            nameof(EntityMetadata.LogicalName)
                        }
                    }
                }
            };

            var resp = (RetrieveMetadataChangesResponse)Service.Execute(qry);

            return resp.EntityMetadata.Count == 1;
        }

        private List<T> GetCheckedItems<T>(CheckedListBox listBox, ItemCheckEventArgs e)
        {
            var checkedItems = new List<T>();
            foreach (var item in listBox.CheckedItems)
                checkedItems.Add((T)item);

            if (e != null)
            {
                if (e.NewValue == CheckState.Checked)
                    checkedItems.Add((T)listBox.Items[e.Index]);
                else
                    checkedItems.Remove((T)listBox.Items[e.Index]);
            }

            return checkedItems;
        }

        private void entityListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            newRoleToolStripButton.Enabled = GetCheckedItems<string>(entityListBox, e).Any();
            updateRolesToolStripButton.Enabled = newRoleToolStripButton.Enabled && GetCheckedItems<Role>(roleListBox, null).Any();
        }

        private void roleListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            updateRolesToolStripButton.Enabled = newRoleToolStripButton.Enabled && GetCheckedItems<Role>(roleListBox, e).Any();
        }

        private void selectPrivilegeDepth(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var button = (ToolStripDropDownButton) menuItem.OwnerItem;
            button.Image = menuItem.Image;

            var depth = (PrivilegeDepth) Enum.Parse(typeof(PrivilegeDepth), (string) menuItem.Tag);

            if (button == depthToolStripDropDownButton)
                _depth = depth;
            else
                _relatedDepth = depth;
        }

        private void newRoleToolStripButton_Click(object sender, EventArgs e)
        {
            var entities = GetCheckedItems<string>(entityListBox, null);
            var name = "Merge " + String.Join(", ", entities);

            if (MessageBox.Show($"This will create a new security role named '{name}' that includes the privileges required to merge these entities. You can rename the security role later if you require.\r\n\r\nDo you want to proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Creating security role...",
                Work = (worker, args) =>
                {
                    // Find the root business unit
                    var qry = new QueryExpression("businessunit");
                    qry.Criteria.AddCondition("parentbusinessunitid", ConditionOperator.Null);
                    qry.ColumnSet = new ColumnSet("businessunitid");
                    var rootBusinessUnit = Service.RetrieveMultiple(qry).Entities.Single();

                    var roleEntity = new Entity("role");
                    roleEntity["name"] = name;
                    roleEntity["businessunitid"] = rootBusinessUnit.ToEntityReference();
                    roleEntity.Id = Service.Create(roleEntity);

                    var role = new Role(roleEntity);

                    var privileges = new List<RolePrivilege>();

                    // Global: Merge
                    privileges.Add(new RolePrivilege
                    {
                        PrivilegeName = "prvMerge",
                        Depth = PrivilegeDepth.Global
                    });

                    foreach (var entity in entities)
                    {
                        worker.ReportProgress(0, $"Adding privileges to merge {entity} records to {role}");
                        AddMergePrivileges(role, entity, privileges);
                    }

                    Service.Execute(new AddPrivilegesRoleRequest
                    {
                        RoleId = role.EntityReference.Id,
                        Privileges = privileges.ToArray()
                    });

                    args.Result = role;
                },
                ProgressChanged = (args) =>
                {
                    SetWorkingMessage(args.UserState.ToString());
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    roleListBox.Items.Add((Role)args.Result);
                }
            });
        }

        private void updateRolesToolStripButton_Click(object sender, EventArgs e)
        {
            var entities = GetCheckedItems<string>(entityListBox, null);
            var roles = GetCheckedItems<Role>(roleListBox, null);

            if (MessageBox.Show($"This will update the selected security roles to include the privileges required to merge these entities. You can rename the security role later if you require.\r\n\r\nDo you want to proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating security roles...",
                Work = (worker, args) =>
                {
                    ConnectionDetail.MetadataCacheLoader.ConfigureAwait(false).GetAwaiter().GetResult();

                    foreach (var role in roles)
                    {
                        var privileges = new List<RolePrivilege>();

                        // Global: Merge
                        privileges.Add(new RolePrivilege
                        {
                            PrivilegeName = "prvMerge",
                            Depth = PrivilegeDepth.Global
                        });

                        foreach (var entity in entities)
                        {
                            worker.ReportProgress(0, $"Adding privileges to merge {entity} records to {role}");
                            AddMergePrivileges(role, entity, privileges);
                        }

                        // Don't reduce the scope of any existing privileges
                        var existingPrivQry = new QueryByAttribute("roleprivileges");
                        existingPrivQry.AddAttributeValue("roleid", role.EntityReference.Id);
                        existingPrivQry.ColumnSet = new ColumnSet("privilegeid", "privilegedepthmask");
                        existingPrivQry.PageInfo = new PagingInfo { PageNumber = 1, Count = 1000 };

                        var existingPrivs = Service.RetrieveMultiple(existingPrivQry);

                        while (true)
                        {
                            foreach (var priv in existingPrivs.Entities)
                            {
                                var privId = priv.GetAttributeValue<Guid>("privilegeid");
                                var depth = (PrivilegeDepth) Math.Log(priv.GetAttributeValue<int>("privilegedepthmask"), 2);

                                var newPriv = privileges.SingleOrDefault(p => p.PrivilegeId == privId);

                                if (newPriv != null && newPriv.Depth < depth)
                                    privileges.Remove(newPriv);
                            }

                            if (!existingPrivs.MoreRecords)
                                break;

                            existingPrivQry.PageInfo.PageNumber++;
                            existingPrivQry.PageInfo.PagingCookie = existingPrivs.PagingCookie;
                            existingPrivs = Service.RetrieveMultiple(existingPrivQry);
                        }

                        Service.Execute(new AddPrivilegesRoleRequest
                        {
                            RoleId = role.EntityReference.Id,
                            Privileges = privileges.ToArray()
                        });
                    }
                },
                ProgressChanged = (args) =>
                {
                    SetWorkingMessage(args.UserState.ToString());
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            });
        }

        private void AddMergePrivileges(Role role, string entityName, List<RolePrivilege> privileges)
        {
            // Main entity:
            // Read, Write, Share, AppendTo
            var entity = ConnectionDetail.MetadataCache.Single(e => e.LogicalName == entityName);

            AddEntityPrivilege(privileges, entity, PrivilegeType.Read, _depth);
            AddEntityPrivilege(privileges, entity, PrivilegeType.Write, _depth);
            AddEntityPrivilege(privileges, entity, PrivilegeType.Share, _depth);
            AddEntityPrivilege(privileges, entity, PrivilegeType.AppendTo, _depth);

            // Related entities with Merge Cascade set to Cascade All:
            // Append, Write
            var oneToManyEntities = entity.OneToManyRelationships
                .Where(r => r.CascadeConfiguration.Merge == CascadeType.Cascade)
                .Select(r => r.ReferencingEntity);

            var manyToManyEntities = entity.ManyToManyRelationships
                .Select(r => r.Entity1LogicalName == entityName ? r.Entity2LogicalName : r.Entity1LogicalName);

            var relatedEntities = new HashSet<string>();
            relatedEntities.AddRange(oneToManyEntities);
            relatedEntities.AddRange(manyToManyEntities);

            // If main entity can have activities, also include all activity types
            if (entity.HasActivities != false || entity.IsActivityParty != false)
            {
                var activityEntities = ConnectionDetail.MetadataCache
                    .Where(e => e.IsActivity == true)
                    .Select(e => e.LogicalName);

                relatedEntities.AddRange(activityEntities);
            }

            foreach (var relatedEntityName in relatedEntities)
            {
                var relatedEntity = ConnectionDetail.MetadataCache.Single(e => e.LogicalName == relatedEntityName);

                AddEntityPrivilege(privileges, relatedEntity, PrivilegeType.Append, _relatedDepth);
                AddEntityPrivilege(privileges, relatedEntity, PrivilegeType.Write, _relatedDepth);
            }
        }

        private void AddEntityPrivilege(List<RolePrivilege> privileges, EntityMetadata entity, PrivilegeType privilegeType, PrivilegeDepth requestedDepth)
        {
            var privilege = entity.Privileges.SingleOrDefault(prv => prv.PrivilegeType == privilegeType);

            if (privilege == null)
                return;

            // Expand depth as required
            if (requestedDepth == PrivilegeDepth.Basic && !privilege.CanBeBasic)
                requestedDepth = PrivilegeDepth.Local;

            if (requestedDepth == PrivilegeDepth.Local && !privilege.CanBeLocal)
                requestedDepth = PrivilegeDepth.Deep;

            if (requestedDepth == PrivilegeDepth.Deep && !privilege.CanBeDeep)
                requestedDepth = PrivilegeDepth.Global;

            if (requestedDepth == PrivilegeDepth.Global && !privilege.CanBeGlobal)
                return;

            var existing = privileges.SingleOrDefault(prv => prv.PrivilegeId == privilege.PrivilegeId);

            if (existing == null)
            {
                privileges.Add(new RolePrivilege
                {
                    PrivilegeId = privilege.PrivilegeId,
                    Depth = requestedDepth
                });
            }
            else if (existing.Depth < requestedDepth)
            {
                existing.Depth = requestedDepth;
            }
        }

        private void aboutToolStripLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://markcarrington.dev/merge-permissions/");
        }
    }
}