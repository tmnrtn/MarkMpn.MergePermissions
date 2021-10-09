using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MarkMpn.MergePermissions
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Merge Permissions"),
        ExportMetadata("Description", "Create or update security roles that allow merging records"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAzUExURSWpVP///1y/f5LUqcjp1Do6Oi9yRzVWQR+YaxmGghN1mA1kryODZkqLw4ax18LY6wAAAOaZl8kAAAARdFJOU/////////////////////8AJa2ZYgAAAAlwSFlzAAAOwwAADsMBx2+oZAAAAMBJREFUOE/VkdsSgjAMRNOLqMSk/P/XuoEUGnhynHHG87bN6aYoLQ5RSrSng/8T8ldCoZIqZU8HQUBF8bhzlFJOqLgYg2AVhShHhW6dyZ6ZaqYTPgYT5QqllOjgqIOELSdGAR+BF1SrORhWgPta+njOM3eiAGV6+cS5/LjCLNqaL8AKP+/gjvpo4yQoi11WRdFGFJQZ47ZPQRTWfliifjD+FwYL7sPyaARBrUDC/Co0Fk8bQbAnCntwPhf418KyvAFuaS2f8o8ckwAAAABJRU5ErkJggg=="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAMAAAC5zwKfAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAzUExURSWpVP///1y/f5LUqcjp1Do6Oi9yRyqNTRmGghN1mA1krzVWQR5re0qLw4ax18LY6wAAAEp+eNoAAAARdFJOU/////////////////////8AJa2ZYgAAAAlwSFlzAAAOwwAADsMBx2+oZAAAAeFJREFUWEftldtygzAMRMEhLUnK5f+/tkZaDARbWs90pnngPHls62RlJZNmztAstAuywi7HJVREcwlZLqEimkvI4gjDxwtvy+qGbQpGWBUxe1ka7cT458LqnrNCtWzCmoieUHuuiFgW6lQQkTfmuxGJPqJG5I154b5njUg/oyFEz6uRzFj4ZFUcjQFnNgXhIaL+oiOMsvQ2IlgjJmMTXGdzz/Ml9Rh06poBghN6Cl/bdimkB+pPaMQAX4QNifoz33KcnjHCpUR5Bj3fZYx0IXhW3MzQ4UaaDIUhTK+2b9vFEqaMNUpTuI0hBLZxW7j7jSzOjrAaU1b0+3ig7/vH41nAFa5fyJW+R2UBQnh/bUrHFmGEEXX6OloYef2gxIb+r5gHVETGcZow1BO0EK5oK7oEUjjC9hxRV4QUsjpWCJ/drEIJdR4DSpRpGHZj2mCEWrhvd8q6BEKoA9nlSxPKQQj1ImRmugVfqPVpHma8iC+Ua+kBU7xhwPkbrlAN0CVfwRZxhVK/BkS/ZR0pXCcM34ijLJ5QeoQQPpwU8ISiwIhlbefjhIeAjs8TigRCyucJ5Qm1Yw2I/TKVQjdghXBZ+QE9oVjER3ZcKfQ75oXSPHYt/k8oK+xaXMJ3RHMJbT5dOM+/yhcWKo1zJxoAAAAASUVORK5CYII="),
        ExportMetadata("BackgroundColor", "DarkMagenta"),
        ExportMetadata("PrimaryFontColor", "White"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MergePermissionsPlugin : PluginBase, IPayPalPlugin
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MergePermissionsPluginControl();
        }

        string IPayPalPlugin.DonationDescription => "Merge Permissions Donation";

        string IPayPalPlugin.EmailAccount => "donate@markcarrington.dev";
    }
}