using isit_7.storage;
using isit_7.stored_procedures;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isit_7
{
    public class MainForm : Form
    {
        protected readonly TabControl main_tab_control;
        protected readonly TDIContainer m_container;

        public MainForm(in TDIContainer container)
        {
            m_container = container;
            main_tab_control = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(main_tab_control);

            CreateStoredProceduresTab();
        }

        private void CreateStoredProceduresTab()
        {
            // Создаем основную вкладку для хранимых процедур
            var storedProceduresTab = new TabPage("Хранимые процедуры");
            main_tab_control.TabPages.Add(storedProceduresTab);

            // Создаем вложенный TabControl
            var nestedTabControl = new TabControl { Dock = DockStyle.Fill };
            storedProceduresTab.Controls.Add(nestedTabControl);

            // Добавляем вкладку "Добавление часов"
            CreateAddHoursTab(nestedTabControl);
        }

        private void CreateAddHoursTab(TabControl parentTabControl)
        {
            var addHoursTab = new TabPage("Добавление часов");
            parentTabControl.TabPages.Add(addHoursTab);

            var view = new TAddHoursView { Dock = DockStyle.Fill };
            addHoursTab.Controls.Add(view);
            var model = new TAddHoursModel(m_container.GetService<IExamStorage>());
            var controller = new TAddHoursController(model, view);
        }
    }
}
