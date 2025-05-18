using System;

namespace isit_7
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = new TDIContainer();
            container.GetService<TApplication>().Run();
        }
    }
}
