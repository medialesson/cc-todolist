using System.Collections.Generic;
using TodoList.Data;

namespace TodoList.Repositories
{
    public interface ITodoRepository
    {
        void AddItem(TodoItem item);
        void AddItem(string title, string content = "", bool isCompleted = false);
        void RemoveItem(TodoItem item);
        void RemoveItemById(string id);
        IEnumerable<TodoItem> GetAllItems();
        TodoItem GetItem(string id);
        void UpdateItem(TodoItem item);
        void Sort();
    }
}