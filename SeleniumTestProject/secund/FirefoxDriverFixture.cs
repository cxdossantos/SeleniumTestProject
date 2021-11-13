using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.secund
{
    public class FirefoxDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Start(BrowserType.Firefox);
        }

        public int WAIT_FOR_ELEMENT_TIMEOUT => 60;
    }
}
