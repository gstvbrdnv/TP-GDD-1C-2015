using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico;
using System.Globalization;
using System.Threading;

namespace PagoElectronico
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
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Application.Run(new PagoElectronico.Login.frmLogin());
        }
    }
}
