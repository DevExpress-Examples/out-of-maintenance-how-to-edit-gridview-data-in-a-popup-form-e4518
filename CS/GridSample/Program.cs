// Developer Express Code Central Example:
// How to edit GridView data in a popup form
// 
// This example demonstrates how to switch a GridView to read-only mode and
// implement the Create, Update, Delete, and Insert operations in a popup form. In
// this example, you can also edit data after double-clicking a row.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4518

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace GridSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            //DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Xmas 2008 Blue");

            Application.Run(new Form1());
        }
    }
}