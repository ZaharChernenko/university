using System.Windows.Forms;

namespace isit_7
{
    public class TMainForm : Form
    {
        public TMainForm(stored_procedures.TTabPage storedProceduresTab, word.TWordTabPage wordTabPage)
        {
            mTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mTabControl);

            storedProceduresTab.Dock = DockStyle.Fill;
            mTabControl.TabPages.Add(storedProceduresTab);
            mTabControl.TabPages.Add(wordTabPage);
        }

        protected readonly TabControl mTabControl;
    }

    public class TMainControllersAggregator
    {
        public TMainControllersAggregator(stored_procedures.TStoredProceduresControllersAggregator storedAggregator, word.TWordController wordController)
        {
            mStoredAggregator = storedAggregator;
            mWordController = wordController;
        }

        protected readonly stored_procedures.TStoredProceduresControllersAggregator mStoredAggregator;
        protected readonly word.TWordController mWordController;
    }
}
