using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace DS.RevitCmd.MVVMTemplate
{
    [Transaction(TransactionMode.Manual)]
    public class ExternalCommand : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData,
           ref string message, ElementSet elements)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();

            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}