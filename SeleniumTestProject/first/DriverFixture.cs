using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumTestProject.first
{
    public class DriverFixture : IDisposable
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        public DriverFixture()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
            Driver = new ChromeDriver();
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        public WebDriverWait WebDriverWait { get; set; }
        public IWebDriver Driver { get; set; }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
