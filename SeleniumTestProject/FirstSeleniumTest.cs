using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace SeleniumTestProject
{
    public class FirstSeleniumTest
    {

        //[Fact]
        [SkippableFact(typeof(DriverServiceNotFoundException))]
        public void CorrectTitleDisplayed_When_NavigateToHomePage()
        {
            //new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("--headless");

            using var driver = new OperaDriver();

            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            Assert.Equal("Sample page - lambdatest.com", driver.Title);
        }
    }
}
