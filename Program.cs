using System;
using TrimCalc.UI;

namespace TrimCalc
{
    class Program
    {
        static void Main()
        {
            SpaceVIL.Common.CommonService.InitSpaceVILComponents();
            var mw = new MainWindow();
            mw.Show();
        }
    }
}
