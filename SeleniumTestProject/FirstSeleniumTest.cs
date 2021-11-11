using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SeleniumTestProject
{
    public class FirstSeleniumTest : IDisposable
    {

        // Fechando Navegador com interface IDisposable
        private IWebDriver _driver;

        public FirstSeleniumTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Fact]
        public void CorrectTitleDisplayed_When_NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");

            Assert.Equal("Sample page - lambdatest.com", _driver.Title);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
