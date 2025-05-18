using isit_7.stored_procedures.isit_7.stored_procedures;
using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TTabPage : TabPage
    {
        public TTabPage(TAddHoursTabPage addHours, TAddCashWhereEqualToTabPage addCashWhereEqualTo, TAddCashTabPage addCash, TMathOperationsTabPage math) {
            Text = "Хранимые процедуры";

            mNestedTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mNestedTabControl);

            mNestedTabControl.TabPages.Add(addHours);
            mNestedTabControl.TabPages.Add(addCashWhereEqualTo);
            mNestedTabControl.TabPages.Add(addCash);
            mNestedTabControl.TabPages.Add(math);
        }

        protected readonly TabControl mNestedTabControl;
    }

    public class TControllersAggregator
    {
        public TControllersAggregator(TAddHoursController addHours, TAddCashWhereEqualToController addCashWhereEqualTo, TAddCashController addCash, TMathOperationsController math)
        {
            mAddHours = addHours;
            mAddCashWhereEqualTo = addCashWhereEqualTo;
            mAddCash = addCash;
            mMathOperations = math;
        }

        protected readonly TAddHoursController mAddHours;
        protected readonly TAddCashWhereEqualToController mAddCashWhereEqualTo;
        protected readonly TAddCashController mAddCash;
        protected readonly TMathOperationsController mMathOperations;
    }
}
