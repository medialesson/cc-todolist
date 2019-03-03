using System.Collections.Generic;
using TodoList.Data;

namespace TodoList.Repositories
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Adds a new item to the to-do list
        /// </summary>
        /// <param name="item">The item to add to the list</param>
        void AddItem(TodoItem item);

        /// <summary>
        /// Adds a new item and let's you fill in input parameters
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="content">Description</param>
        /// <param name="isCompleted">Specifies whether the item is completed</param>
        void AddItem(string title, string content = "", bool isCompleted = false);

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        /// <param name="item">The item to remove</param>
        void RemoveItem(TodoItem item);

        /// <summary>
        /// Removes an item from the list by ID
        /// </summary>
        /// <param name="id">The ID associated to the item that shall be removed</param>
        void RemoveItemById(string id);

        /// <summary>
        /// Gets all items and returns them as enumerable
        /// </summary>
        /// <returns>Enumerable list of all items</returns>
        IEnumerable<TodoItem> GetAllItems();

        /// <summary>
        /// Gets item by ID
        /// </summary>
        /// <param name="id">The ID of the associated item</param>
        /// <returns></returns>
        TodoItem GetItem(string id);

        /// <summary>
        /// Updates an item
        /// </summary>
        /// <param name="item"></param>
        void UpdateItem(TodoItem item);

        /// <summary>
        /// Sorts items
        /// </summary>
        void Sort();
    }
}