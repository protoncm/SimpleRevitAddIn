#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace Simple_Revit_AddIn
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Access current selection

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Simple");
                string dialogTitle = "Simple Add-In";
                string description = "Hey! This is very simple add-in";
                TaskDialog.Show(dialogTitle, description);
                tx.Commit();
            }

            return Result.Succeeded;
        }
    }
}
