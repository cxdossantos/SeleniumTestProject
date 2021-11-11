using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace SeleniumTestProject
{
    public class FirstSeleniumTest
    {

        [Fact]
        public void CorrectTitleDisplayed_When_NavigateToHomePage()
        {
            // Na ultima vers�o do dotnet, n�o � necess�rio utilizar 'chaves'
            using var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            Assert.Equal("Sample page - lambdatest.com", driver.Title);
        }
    }
}
