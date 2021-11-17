using SeleniumTestProject.third.pages;
using System.Collections.Generic;

namespace SeleniumTestProject.third
{
    public class ToDoFacade
    {
        private readonly MainPage _mainPage;
        private readonly ToDoAppPage _toDoAppPage;

        public ToDoFacade(MainPage mainPage, ToDoAppPage toDoAppPage)
        {
            _mainPage = mainPage;
            _toDoAppPage = toDoAppPage;
        }

        public void VerifyTodoListCreatedSuccessfuly(string technology, List<string> itemsToAdd, List<string> itemsToCheck, int expectedItemsLeft)
        {
            _mainPage.Open();
            _mainPage.OpenTehnologyApp(technology);

            itemsToAdd.ForEach(item => _toDoAppPage.AddNewTodoItem(item));
            itemsToCheck.ForEach(item => _toDoAppPage.GetItemCheckbox(item).Click());
            _toDoAppPage.AssertLeftItems(expectedItemsLeft);
        }

    }
}
