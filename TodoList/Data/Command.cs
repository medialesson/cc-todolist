using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Data
{
    public class Command
    {
        public string Key { get; set; }

        public Action Action { get; set; }

        public Command(string key, Action action)
        {
            Key = key;
            Action = action;
        }

        public void Execute()
        {
            Action.Invoke();
        }
    }
}
