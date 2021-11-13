namespace SeleniumTestProject.third
{
    public class FirefoxDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Value.Start(BrowserType.Firefox);
        }

        public int WAIT_FOR_ELEMENT_TIMEOUT => 60;
    }
}
