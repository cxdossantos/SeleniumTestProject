using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.first;
using System;
using System.ComponentModel;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace SeleniumTestProject
{
    public class CompileToJsTodoTests : IClassFixture<DriverFixture>
    {
        private readonly DriverFixture _fixture;

        public CompileToJsTodoTests(DriverFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("Kotlin + React")]
        [InlineData("Spine")]
        [InlineData("Dart")]
        [InlineData("GWT")]
        [InlineData("Closure")]
        [InlineData("Elm")]
        [InlineData("AngularDart")]
        [InlineData("TypeScript + Backbone.js")]
        [InlineData("TypeScript + AngularJS")]
        [InlineData("AngularJS")]
        [InlineData("Dojo")]
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
