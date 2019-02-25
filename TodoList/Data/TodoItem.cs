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
            Id = Guid.NewGuid().ToString();
            IsCompleted = false;
            AddedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"#{Id} - {Title} - {Content} - " +
                   $"{(IsCompleted ? "Completed" : "Pending")} - " +
                   $"{AddedAt.ToLocalTime()}";
        }
    }
}
