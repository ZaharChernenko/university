using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TTabPage : TabPage
    {
        public TTabPage(TAddHoursTabPage addHoursTabPage, TAddCashWhereEqualToTabPage addCashWhereEqualToTabPage) {
            Text = "Хранимые процедуры";

            mNestedTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mNestedTabControl);

            mNestedTabControl.TabPages.Add(addHoursTabPage);
            mNestedTabControl.TabPages.Add(addCashWhereEqualToTabPage);
        }

        protected readonly TabControl mNestedTabControl;
    }

    public class TControllersAggregator
    {
        public TControllersAggregator(TAddHoursController addHoursController, TAddCashWhereEqualToController addCashWhereEqualToController)
        {
            mAddHoursController = addHoursController;
            mAddCashWhereEqualToController = addCashWhereEqualToController;
        }

        protected readonly TAddHoursController mAddHoursController;
        protected readonly TAddCashWhereEqualToController mAddCashWhereEqualToController;
    }
}
