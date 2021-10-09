
namespace MarkMpn.MergePermissions
{
    partial class MergePermissionsPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergePermissionsPluginControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.entityListBox = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.roleListBox = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newRoleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.updateRolesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.depthToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parentChildBusinessUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatedDepthToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.userToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.businessUnitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parentChildBusinessUnitsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1017, 499);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.entityListBox);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 499);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mergeable Tables";
            // 
            // entityListBox
            // 
            this.entityListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityListBox.FormattingEnabled = true;
            this.entityListBox.Location = new System.Drawing.Point(3, 41);
            this.entityListBox.Name = "entityListBox";
            this.entityListBox.Size = new System.Drawing.Size(330, 455);
            this.entityListBox.TabIndex = 2;
            this.entityListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entityListBox_ItemCheck);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(330, 25);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the tables users should be able to merge.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.roleListBox);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 499);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Security Roles";
            // 
            // roleListBox
            // 
            this.roleListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleListBox.FormattingEnabled = true;
            this.roleListBox.Location = new System.Drawing.Point(3, 41);
            this.roleListBox.Name = "roleListBox";
            this.roleListBox.Size = new System.Drawing.Size(671, 455);
            this.roleListBox.TabIndex = 6;
            this.roleListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.roleListBox_ItemCheck);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRoleToolStripButton,
            this.updateRolesToolStripButton,
            this.toolStripSeparator1,
            this.depthToolStripDropDownButton,
            this.relatedDepthToolStripDropDownButton,
            this.aboutToolStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(671, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newRoleToolStripButton
            // 
            this.newRoleToolStripButton.Enabled = false;
            this.newRoleToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newRoleToolStripButton.Image")));
            this.newRoleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newRoleToolStripButton.Name = "newRoleToolStripButton";
            this.newRoleToolStripButton.Size = new System.Drawing.Size(77, 22);
            this.newRoleToolStripButton.Text = "New Role";
            this.newRoleToolStripButton.ToolTipText = "Create a new security role with the privileges required to merge records in the s" +
    "elected tables.";
            this.newRoleToolStripButton.Click += new System.EventHandler(this.newRoleToolStripButton_Click);
            // 
            // updateRolesToolStripButton
            // 
            this.updateRolesToolStripButton.Enabled = false;
            this.updateRolesToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("updateRolesToolStripButton.Image")));
            this.updateRolesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateRolesToolStripButton.Name = "updateRolesToolStripButton";
            this.updateRolesToolStripButton.Size = new System.Drawing.Size(96, 22);
            this.updateRolesToolStripButton.Text = "Update Roles";
            this.updateRolesToolStripButton.ToolTipText = "Update the selected security roles with the privileges required to merge records " +
    "in the selected tables.";
            this.updateRolesToolStripButton.Click += new System.EventHandler(this.updateRolesToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // depthToolStripDropDownButton
            // 
            this.depthToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.businessUnitToolStripMenuItem,
            this.parentChildBusinessUnitsToolStripMenuItem,
            this.organizationToolStripMenuItem});
            this.depthToolStripDropDownButton.Image = global::MarkMpn.MergePermissions.Properties.Resources.Global;
            this.depthToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.depthToolStripDropDownButton.Name = "depthToolStripDropDownButton";
            this.depthToolStripDropDownButton.Size = new System.Drawing.Size(108, 22);
            this.depthToolStripDropDownButton.Text = "Main Records";
            this.depthToolStripDropDownButton.ToolTipText = "Select what records the users will be allowed to merge";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Image = global::MarkMpn.MergePermissions.Properties.Resources.Basic;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.userToolStripMenuItem.Tag = "Basic";
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.ToolTipText = "Users will be able to merge records they own";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // businessUnitToolStripMenuItem
            // 
            this.businessUnitToolStripMenuItem.Image = global::MarkMpn.MergePermissions.Properties.Resources.Local;
            this.businessUnitToolStripMenuItem.Name = "businessUnitToolStripMenuItem";
            this.businessUnitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.businessUnitToolStripMenuItem.Tag = "Local";
            this.businessUnitToolStripMenuItem.Text = "Business Unit";
            this.businessUnitToolStripMenuItem.ToolTipText = "Users will be able to merge records in their business unit";
            this.businessUnitToolStripMenuItem.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // parentChildBusinessUnitsToolStripMenuItem
            // 
            this.parentChildBusinessUnitsToolStripMenuItem.Image = global::MarkMpn.MergePermissions.Properties.Resources.Deep;
            this.parentChildBusinessUnitsToolStripMenuItem.Name = "parentChildBusinessUnitsToolStripMenuItem";
            this.parentChildBusinessUnitsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.parentChildBusinessUnitsToolStripMenuItem.Tag = "Deep";
            this.parentChildBusinessUnitsToolStripMenuItem.Text = "Parent: Child Business Units";
            this.parentChildBusinessUnitsToolStripMenuItem.ToolTipText = "Users will be able to merge records in their business unit or any child business " +
    "unit";
            this.parentChildBusinessUnitsToolStripMenuItem.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // organizationToolStripMenuItem
            // 
            this.organizationToolStripMenuItem.Image = global::MarkMpn.MergePermissions.Properties.Resources.Global;
            this.organizationToolStripMenuItem.Name = "organizationToolStripMenuItem";
            this.organizationToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.organizationToolStripMenuItem.Tag = "Global";
            this.organizationToolStripMenuItem.Text = "Organization";
            this.organizationToolStripMenuItem.ToolTipText = "Users will be able to merge any record";
            this.organizationToolStripMenuItem.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // relatedDepthToolStripDropDownButton
            // 
            this.relatedDepthToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem1,
            this.businessUnitToolStripMenuItem1,
            this.parentChildBusinessUnitsToolStripMenuItem1,
            this.organizationToolStripMenuItem1});
            this.relatedDepthToolStripDropDownButton.Image = global::MarkMpn.MergePermissions.Properties.Resources.Global;
            this.relatedDepthToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.relatedDepthToolStripDropDownButton.Name = "relatedDepthToolStripDropDownButton";
            this.relatedDepthToolStripDropDownButton.Size = new System.Drawing.Size(120, 22);
            this.relatedDepthToolStripDropDownButton.Text = "Related Records";
            this.relatedDepthToolStripDropDownButton.ToolTipText = resources.GetString("relatedDepthToolStripDropDownButton.ToolTipText");
            // 
            // userToolStripMenuItem1
            // 
            this.userToolStripMenuItem1.Image = global::MarkMpn.MergePermissions.Properties.Resources.Basic;
            this.userToolStripMenuItem1.Name = "userToolStripMenuItem1";
            this.userToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.userToolStripMenuItem1.Tag = "Basic";
            this.userToolStripMenuItem1.Text = "User";
            this.userToolStripMenuItem1.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // businessUnitToolStripMenuItem1
            // 
            this.businessUnitToolStripMenuItem1.Image = global::MarkMpn.MergePermissions.Properties.Resources.Local;
            this.businessUnitToolStripMenuItem1.Name = "businessUnitToolStripMenuItem1";
            this.businessUnitToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.businessUnitToolStripMenuItem1.Tag = "Local";
            this.businessUnitToolStripMenuItem1.Text = "Business Unit";
            this.businessUnitToolStripMenuItem1.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // parentChildBusinessUnitsToolStripMenuItem1
            // 
            this.parentChildBusinessUnitsToolStripMenuItem1.Image = global::MarkMpn.MergePermissions.Properties.Resources.Deep;
            this.parentChildBusinessUnitsToolStripMenuItem1.Name = "parentChildBusinessUnitsToolStripMenuItem1";
            this.parentChildBusinessUnitsToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.parentChildBusinessUnitsToolStripMenuItem1.Tag = "Deep";
            this.parentChildBusinessUnitsToolStripMenuItem1.Text = "Parent: Child Business Units";
            this.parentChildBusinessUnitsToolStripMenuItem1.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // organizationToolStripMenuItem1
            // 
            this.organizationToolStripMenuItem1.Image = global::MarkMpn.MergePermissions.Properties.Resources.Global;
            this.organizationToolStripMenuItem1.Name = "organizationToolStripMenuItem1";
            this.organizationToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.organizationToolStripMenuItem1.Tag = "Global";
            this.organizationToolStripMenuItem1.Text = "Organization";
            this.organizationToolStripMenuItem1.Click += new System.EventHandler(this.selectPrivilegeDepth);
            // 
            // aboutToolStripLabel
            // 
            this.aboutToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripLabel.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripLabel.Image")));
            this.aboutToolStripLabel.IsLink = true;
            this.aboutToolStripLabel.Name = "aboutToolStripLabel";
            this.aboutToolStripLabel.Size = new System.Drawing.Size(229, 22);
            this.aboutToolStripLabel.Text = "Merge Permissions by Mark Carrington";
            this.aboutToolStripLabel.ToolTipText = "Documentation";
            this.aboutToolStripLabel.Click += new System.EventHandler(this.aboutToolStripLabel_Click);
            // 
            // MergePermissionsPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MergePermissionsPluginControl";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(1029, 511);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox entityListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox roleListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newRoleToolStripButton;
        private System.Windows.Forms.ToolStripButton updateRolesToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton depthToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parentChildBusinessUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton relatedDepthToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem businessUnitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parentChildBusinessUnitsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem organizationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripLabel aboutToolStripLabel;
    }
}
