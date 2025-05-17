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
            // var adapter = new TAddHoursModel(container.GetService<IConfiguration>());
            // adapter.AddHours("Прикладной дизайн", 228);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new TDIContainer();
            // Application.Run(new MainForm());
        }
    }
}
