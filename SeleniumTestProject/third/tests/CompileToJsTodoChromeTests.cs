using System.Collections.Generic;
using Xunit;

namespace SeleniumTestProject.third
{
    public class CompileToJsTodoChromeTests : IClassFixture<ChromeDriverFixture>, IClassFixture<PagesFixture>
    {
        private readonly ChromeDriverFixture _fixture;
        private readonly PagesFixture _pagesFixture;
        public CompileToJsTodoChromeTests(ChromeDriverFixture fixture, PagesFixture pagesFixture)
        {
            _fixture = fixture;
            _pagesFixture = pagesFixture;
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

            var itemsAdd = new List<string>() {"Clean the Car", "Clean the House", "Clean the Room", "Clean the Club" };
            var itemsCheck = new List<string>() { "Clean the Club" };

            _pagesFixture.ToDoFacade.VerifyTodoListCreatedSuccessfuly(technology, itemsAdd, itemsCheck, 2);
        }
    }
}
