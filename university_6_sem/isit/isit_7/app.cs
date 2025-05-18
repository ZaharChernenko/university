using System.Windows.Forms;

namespace isit_7
{
    public class TApplication
    {
        public TApplication(TMainControllersAggregator aggregator, TMainForm form)
        {
            mForm = form;
            mAggregator = aggregator;
        }

        public void Run()
        {
            Application.Run(mForm);
        }

        protected readonly TMainForm mForm;
        protected readonly TMainControllersAggregator mAggregator;
    }
}
