using GUI.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
           

            // Mendapatkan direktori induk sebanyak dua kali untuk naik dua level
            //DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            //DirectoryInfo parentDirectory = directoryInfo.Parent.Parent.Parent.Parent.Parent;

            // Mendapatkan path dari direktori induk yang telah ditentukan
            //string desiredDirectory = parentDirectory.FullName;
           

            //MessageBox.Show(desiredDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }
    }
}
