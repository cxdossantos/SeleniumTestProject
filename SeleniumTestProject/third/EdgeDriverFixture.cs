namespace SeleniumTestProject.third
{
    public class EdgeDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Value.Start(BrowserType.Edge);
        }

        public override int WaitForElement => 60;
    }
}
