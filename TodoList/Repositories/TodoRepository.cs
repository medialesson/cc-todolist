using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoList.Data;

namespace TodoList.Repositories
{
    public class TodoRepository
    {
        private IList<TodoItem> _todoList;

        public TodoRepository()
        {
            _todoList = new List<TodoItem>();
        }

        public void AddItem(TodoItem item)
        {
            _todoList.Add(item);
        }

        public void AddItem(string title, string content = "", bool isCompleted = false)
        {
            AddItem(new TodoItem()
            {
                Title = title,
                Content = content,
                IsCompleted = isCompleted
            });
        }

        public void RemoveItem(TodoItem item)
        {
            _todoList.Remove(item);
        }

        public void RemoveItemById(string id)
        {
            var item = _todoList.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return;

            _todoList.Remove(item);
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            return _todoList.ToList();
        }
    }
}
