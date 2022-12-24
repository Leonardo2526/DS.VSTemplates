using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DS.RevitApp.RibbonTemplate
{
    internal class Button
    {
        public static PushButtonData button1;

        string ButtonPath;
        string ButtonDescription;

        public void AddButtons()
        {
            //Create button1
            string button1Name = "DS.RVT.Test";
            AddButton1(button1Name);
        }

        void AddButton1(string buttonName)
        {
            AssignProperties(buttonName);

            // Create push button
            button1 = new PushButtonData(buttonName, buttonName, ButtonPath, buttonName + ".ExternalCommand")
            {
                ToolTip = ButtonDescription
            };
        }

        void AssignProperties(string buttonName)
        {
            string path = String.Format(@"%AppData%\Autodesk\Revit\Addins\2020\{0}\{0}.dll", buttonName);
            ButtonPath = Environment.ExpandEnvironmentVariables(path);

            Assembly assembly = Assembly.LoadFrom(ButtonPath);

            var descriptionAttribute1 = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).
                OfType<AssemblyDescriptionAttribute>().FirstOrDefault();

            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            ButtonDescription = descriptionAttribute1.Description + "\nProduct version: " + version;
        }
    }
}
