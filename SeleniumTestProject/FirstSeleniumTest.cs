using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;

namespace SeleniumTestProject
{
    public class FirstSeleniumTest
    {

        [Fact]
        public void CorrectTitleDisplayed_When_NavigateToHomePage()
        {
            // Na ultima versão do dotnet, não é necessário utilizar 'chaves'
            using var driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            Assert.Equal("Sample page - lambdatest.com", driver.Title);
        }
    }
}
