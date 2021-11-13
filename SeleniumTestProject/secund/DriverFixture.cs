using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumTestProject.secund
{
    public abstract class DriverFixture : IDisposable
    {
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        public DriverFixture()
        {
            Driver = new DriverAdapter();
            InitializeDriver();
        }

        protected abstract void InitializeDriver();
        public WebDriverWait WebDriverWait { get; set; }
        public DriverAdapter Driver { get; set; }
        public virtual int WaitForElement { get; set; } = WAIT_FOR_ELEMENT_TIMEOUT;

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
