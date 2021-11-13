namespace SeleniumTestProject.third
{
    public class ChromeDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Value.Start(BrowserType.Chrome);
        }
        public override int WaitForElement => 40;
    }
}
