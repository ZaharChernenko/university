using System.Windows.Forms;

namespace isit_7
{
    public class TMainForm : Form
    {
        public TMainForm(stored_procedures.TTabPage storedProcuduresTab)
        {
            mTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mTabControl);

            storedProcuduresTab.Dock = DockStyle.Fill;
            mTabControl.TabPages.Add(storedProcuduresTab);
        }

        protected readonly TabControl mTabControl;
    }

    public class TMainControllersAggregator
    {
        public TMainControllersAggregator(stored_procedures.TControllersAggregator storedAggregator)
        {
            mStoredAggregator = storedAggregator;
        }

        protected readonly stored_procedures.TControllersAggregator mStoredAggregator;
    }
}
