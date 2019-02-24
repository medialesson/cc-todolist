using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Data
{
    public class TodoItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime AddedAt { get; set; }

        public TodoItem()
        {
            Id = new Guid().ToString();
            AddedAt = DateTime.Now;
        }
    }
}
