using isit_7.stored_procedures.isit_7.stored_procedures;
using System.Windows.Forms;

namespace isit_7.stored_procedures
{
    public class TTabPage : TabPage
    {
        public TTabPage(TAddHoursTabPage addHours, TAddCashWhereEqualToTabPage addCashWhereEqualTo, TAddCashTabPage addCash, TMathOperationsTabPage math, TAddCashWhere5TabPage addCashWhere5, TAddCashWhereGreaterTabPage addCashWhereGreater) {
            Text = "Хранимые процедуры";

            mNestedTabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(mNestedTabControl);

            mNestedTabControl.TabPages.Add(addHours);
            mNestedTabControl.TabPages.Add(addCashWhereEqualTo);
            mNestedTabControl.TabPages.Add(addCash);
            mNestedTabControl.TabPages.Add(math);
            mNestedTabControl.TabPages.Add(addCashWhere5);
            mNestedTabControl.TabPages.Add(addCashWhereGreater);
        }

        protected readonly TabControl mNestedTabControl;
    }

    public class TControllersAggregator
    {
        public TControllersAggregator(TAddHoursController addHours, TAddCashWhereEqualToController addCashWhereEqualTo, TAddCashController addCash, TMathOperationsController math, TAddCashWhere5Controller addCashWhere5, TAddCashWhereGreaterController addCashWhereGreater)
        {
            mAddHours = addHours;
            mAddCashWhereEqualTo = addCashWhereEqualTo;
            mAddCash = addCash;
            mMathOperations = math;
            mAddCashWhere5 = addCashWhere5;
            mAddCashWhereGreater = addCashWhereGreater;
        }

        protected readonly TAddHoursController mAddHours;
        protected readonly TAddCashWhereEqualToController mAddCashWhereEqualTo;
        protected readonly TAddCashController mAddCash;
        protected readonly TMathOperationsController mMathOperations;
        protected readonly TAddCashWhere5Controller mAddCashWhere5;
        protected readonly TAddCashWhereGreaterController mAddCashWhereGreater;
    }
}
