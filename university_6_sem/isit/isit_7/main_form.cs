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
        protected readonly TabControl mTabControl;

        public MainForm(stored_procedures.TTabPage storedProcuduresTab)
        {
            mTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mTabControl);

            storedProcuduresTab.Dock = DockStyle.Fill;
            mTabControl.TabPages.Add(storedProcuduresTab);

        }
    }
}
