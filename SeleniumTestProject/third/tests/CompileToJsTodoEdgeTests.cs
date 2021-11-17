using System.Collections.Generic;
using Xunit;

namespace SeleniumTestProject.third
{
    public class CompileToJsTodoEdgeTests : IClassFixture<EdgeDriverFixture>, IClassFixture<PagesFixture>, IClassFixture<TestDataFixture>
    {
        private readonly EdgeDriverFixture _fixture;
        private readonly PagesFixture _pagesFixture;
        private readonly TestDataFixture _testDataFixture;
        public CompileToJsTodoEdgeTests(EdgeDriverFixture fixture, PagesFixture pagesFixture, TestDataFixture testDataFixture)
        {
            _fixture = fixture;
            _pagesFixture = pagesFixture;
            _testDataFixture = testDataFixture;
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
            _pagesFixture.ToDoFacade.VerifyTodoListCreatedSuccessfuly(technology, _testDataFixture.ItemsAdd, _testDataFixture.ItemsCheck, _testDataFixture.ExpectdItemsLeft);
        }
    }
}
