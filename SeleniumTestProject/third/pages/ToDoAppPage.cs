using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.third.pages
{
    public class ToDoAppPage
    {
        private readonly DriverAdapter _driver;

        public ToDoAppPage(DriverAdapter driver)
        {
            _driver = driver;
        }

        public void AssertLeftItems(int expectedCount)
        {
            var resultSpan = _driver.FindElement(By.XPath("//footer/*/span | //footer/span"));
            if (expectedCount <= 0)
            {
                _driver.ValidadeInnerTextIs(resultSpan, $"{expectedCount} item left");
            }
            else
            {
                _driver.ValidadeInnerTextIs(resultSpan, $"{expectedCount} items left");
            }
        }

        public IWebElement GetItemCheckbox(string todoItem)
        {
            return _driver.FindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
        }

        public void AddNewTodoItem(string todoItem)
        {
            var todoInput = _driver.FindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
            todoInput.SendKeys(todoItem);
            todoInput.SendKeys(Keys.Enter);
        }
    }
}
