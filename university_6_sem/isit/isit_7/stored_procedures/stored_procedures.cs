using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TTabPage : TabPage
    {
        public TTabPage(TAddHoursTabPage addHoursTabPage, TAddCashWhereEqualToTabPage addCashWhereEqualToTabPage, TAddCashTabPage addCashTabPage) {
            Text = "Хранимые процедуры";

            mNestedTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mNestedTabControl);

            mNestedTabControl.TabPages.Add(addHoursTabPage);
            mNestedTabControl.TabPages.Add(addCashWhereEqualToTabPage);
            mNestedTabControl.TabPages.Add(addCashTabPage);
        }

        protected readonly TabControl mNestedTabControl;
    }

    public class TControllersAggregator
    {
        public TControllersAggregator(TAddHoursController addHoursController, TAddCashWhereEqualToController addCashWhereEqualToController, TAddCashController addCashController)
        {
            mAddHoursController = addHoursController;
            mAddCashWhereEqualToController = addCashWhereEqualToController;
            mAddCashController = addCashController;
        }

        protected readonly TAddHoursController mAddHoursController;
        protected readonly TAddCashWhereEqualToController mAddCashWhereEqualToController;
        protected readonly TAddCashController mAddCashController;
    }
}
