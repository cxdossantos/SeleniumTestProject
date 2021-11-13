using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.first;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace SeleniumTestProject.third
{
    public class PureJsTodoTests : IClassFixture<DriverFixture>
    {
        private readonly ChromeDriverFixture _fixture;
        private readonly PagesFixture _pagesFixture;
        public PureJsTodoTests(ChromeDriverFixture fixture, PagesFixture pagesFixture)
        {
            _fixture = fixture;
            _pagesFixture = pagesFixture;
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
        public void VerifyTodoListCreateSuccessfully(string technology)
        {

            var itemsAdd = new List<string>() { "Clean the Car", "Clean the House", "Clean the Room", "Clean the Club" };
            var itemsCheck = new List<string>() { "Clean the Club" };

            _pagesFixture.ToDoFacade.VerifyTodoListCreatedSuccessfuly(technology, itemsAdd, itemsCheck, 2);
        }
    }
}
