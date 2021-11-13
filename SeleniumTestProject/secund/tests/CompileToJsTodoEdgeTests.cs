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

namespace SeleniumTestProject.secund
{
    public class CompileToJsTodoEdgeTests : IClassFixture<EdgeDriverFixture>
    {
        private readonly EdgeDriverFixture _fixture;

        public CompileToJsTodoEdgeTests(EdgeDriverFixture fixture)
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
            _fixture.Driver.GoToUrl("https://todomvc.com");
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
            var resultSpan = _fixture.Driver.FindElement(By.XPath("//footer/span"));
            if (expectedCount <= 0)
            {
                _fixture.Driver.ValidadeInnerTextIs(resultSpan, $"{expectedCount} item left");
            }
            else
            {
                _fixture.Driver.ValidadeInnerTextIs(resultSpan, $"{expectedCount} items left");
            }
        }

        private IWebElement GetItemCheckbox(string todoItem)
        {
            return _fixture.Driver.FindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
        }

        private void AddNewTodoItem(string todoItem)
        {
            var todoInput = _fixture.Driver.FindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
            todoInput.SendKeys(todoItem);
            todoInput.SendKeys(Keys.Enter);

        }

        private void OpenTehnologyApp(string name)
        {
            IWebElement technologyLink = _fixture.Driver.FindElement(By.LinkText(name));
            technologyLink.Click();
        }
    }
}
