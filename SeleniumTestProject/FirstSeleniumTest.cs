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
            // Ao invés de utilizar uma variavel privada, podemos implementar com o 'using', desta forma ira fechar o navegador automaticamente
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");

                Assert.Equal("Sample page - lambdatest.com", driver.Title);
            }
        }
    }
}
