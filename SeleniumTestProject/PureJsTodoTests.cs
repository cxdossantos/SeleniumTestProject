using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.first;
using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 2)]

namespace SeleniumTestProject
{
    public class PureJsTodoTests : IClassFixture<DriverFixture>
    {
        private readonly DriverFixture _fixture;

        public PureJsTodoTests(DriverFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("Backbone.js")]
        [InlineData("AngularJS")]
        [InlineData("Ember.js")]
        [InlineData("KnockoutJS")]
        [InlineData("Dojo")]
        [InlineData("Knockback.js")]
        [InlineData("CanJS")]
        [InlineData("Polymer")]
        [InlineData("React")]
        [InlineData("Mithril")]
        [InlineData("Vue.js")]
        [InlineData("Marionette.js")]
        [InlineData("SocketStream")]
        [InlineData("Marionette.js")]
        public void VerifyTodoListCreateSuccessfully(string technology)
        {
            _fixture.Driver.Navigate().GoToUrl("https://todomvc.com");
            OpenTehnologyApp(technology);
            AddNewTodoItem("Clean the Car");
            AddNewTodoItem("Clean the House");
            AddNewTodoItem("Clean the Room");
            AddNewTodoItem("Clean the Club");
            GetItemCheckbox("Clean the Room").Click();
            AssertLeftItems(3);
        }

        private void AssertLeftItems(int expectedCount)
        {
            var resultSpan = WaitAndFindElement(By.XPath("//footer/span"));
            if (expectedCount <= 0)
            {
                ValidadeInnerTextIs(resultSpan, $"{expectedCount} item left");
            }
            else
            {
                ValidadeInnerTextIs(resultSpan, $"{expectedCount} items left");
            }
        }

        private void ValidadeInnerTextIs(IWebElement resultSpan, string expectedText)
        {
            _fixture.WebDriverWait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
        }

        private IWebElement GetItemCheckbox(string todoItem)
        {
            return WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
        }

        private void AddNewTodoItem(string todoItem)
        {
            var todoInput = WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
            todoInput.SendKeys(todoItem);
            todoInput.SendKeys(Keys.Enter);
        }

        private void OpenTehnologyApp(string name)
        {
            IWebElement technologyLink = WaitAndFindElement(By.LinkText(name));
            technologyLink.Click();
        }

        private IWebElement WaitAndFindElement(By locator)
        {
            return _fixture.WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
