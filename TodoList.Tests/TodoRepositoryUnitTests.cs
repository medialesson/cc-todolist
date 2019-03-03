using System;
using TodoList.Data;
using TodoList.Repositories;
using Xunit;

namespace TodoList.Tests
{
    public class TodoRepositoryUnitTests
    {
        [Fact]
        public void ShouldAddNewItemAndValidate()
        {
            // Init repository
            ITodoRepository repository = new TodoRepository();
            
            // Init expected variables
            string expectedTitle = "Finish unit tests";
            string expectedContent = "Generic description goes here";

            // Set up new item
            var item = new TodoItem()
            {
                Title = expectedTitle,
                Content = expectedContent
            };

            // Add new item to repository, fetch it by ID
            var newItemId = repository.AddItem(item).Id;
            var foundItem = repository.GetItem(newItemId);

            // Make assertions and check whether new item
            // corresponds to the found item
            Assert.Equal(expectedTitle, foundItem.Title);
            Assert.Equal(expectedContent, foundItem.Content);
        }
    }
}
