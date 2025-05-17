using isit_7.stored_procedures;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isit_7
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new TDIContainer();
            container.GetService<TAddHoursController>();
            container.GetService<TAddHoursTabPage>();
            Application.Run(container.GetService<MainForm>());
        }
    }
}
