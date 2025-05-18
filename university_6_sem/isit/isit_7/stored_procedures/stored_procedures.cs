using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TTabPage : TabPage
    {
        public TTabPage(TAddHoursTabPage addHoursTabPage) {
            Text = "Хранимые процедуры";

            mNestedTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mNestedTabControl);

            mNestedTabControl.TabPages.Add(addHoursTabPage);
        }

        protected readonly TabControl mNestedTabControl;
    }

    public class TControllersAggregator
    {
        public TControllersAggregator(TAddHoursController addHoursController)
        {
            mAddHoursController = addHoursController;
        }

        protected readonly TAddHoursController mAddHoursController;
    }
}
