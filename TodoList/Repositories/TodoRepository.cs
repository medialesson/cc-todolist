﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoList.Data;

namespace TodoList.Repositories
{
    /// <inheritdoc cref="ITodoRepository"/>
    public class TodoRepository : ITodoRepository
    {
        private IList<TodoItem> _todoList;

        public TodoRepository()
        {
            _todoList = new List<TodoItem>();
        }

        public TodoItem AddItem(TodoItem item)
        {
            var id = Guid.NewGuid().ToString();
            item.Id = id;
            _todoList.Add(item);

            return GetItem(id);
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

        public TodoItem GetItem(string id)
        {
            return _todoList.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateItem(TodoItem item)
        {
            var foundItem = _todoList.FirstOrDefault(i => i.Id == item.Id);
            _todoList.Remove(foundItem);

            _todoList.Add(item);
        }

        public void Sort()
        {
            _todoList = _todoList.OrderByDescending(i => i.AddedAt).ToList();
        }
    }
}
