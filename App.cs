#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;

#endregion

namespace Simple_Revit_AddIn
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            // declare variables
            string tabName = "Simple Add In";
            string tabPanelName = "Simple";
            string buttonName = "Simple";
            string buttonClassName = "Simple_Revit_AddIn.Command";
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            // create a new tab for button
            a.CreateRibbonTab(tabName);
            RibbonPanel pannel = a.CreateRibbonPanel(tabName, tabPanelName);
            PushButtonData button = new PushButtonData(buttonName, buttonName, assemblyPath, buttonClassName);

            // add image to button
            button.LargeImage = new BitmapImage(new Uri(@"/Resources/Dynamo.png", UriKind.Relative));
            pannel.AddItem(button);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
