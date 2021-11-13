using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.third
{
    public class SafariDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Value.Start(BrowserType.Safari);
        }

        public override int WaitForElement => 60;
    }
}
