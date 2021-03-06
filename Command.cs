#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Simple_Revit_AddIn.Components;
#endregion

namespace Simple_Revit_AddIn
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private PopupWindow popupWindow = new PopupWindow();
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
                popupWindow.ShowDialog();
                tx.Commit();
            }

            return Result.Succeeded;
        }
    }
}
