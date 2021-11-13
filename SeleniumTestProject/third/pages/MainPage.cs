using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.third.pages
{
    public class MainPage
    {
        private readonly DriverAdapter _driver;

        public MainPage(DriverAdapter driver)
        {
            _driver = driver;
        }

        public string Url => "https://todomvc.com";

        public void Open()
        {
            _driver.GoToUrl("https://todomvc.com");
        }

        public void OpenTehnologyApp(string name)
        {
            IWebElement technologyLink = _driver.FindElement(By.LinkText(name));
            technologyLink.Click();
        }
    }
}
