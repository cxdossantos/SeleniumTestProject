using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace SeleniumTestProject
{
    public class FirstSeleniumTest
    {

        [Fact]
        public void CorrectTitleDisplayed_When_NavigateToHomePage()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");

            // Na ultima vers�o do dotnet, n�o � necess�rio utilizar 'chaves'
            using var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            Assert.Equal("Sample page - lambdatest.com", driver.Title);
        }
    }
}
