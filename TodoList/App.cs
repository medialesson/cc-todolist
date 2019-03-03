using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Repositories;

namespace TodoList
{
    public class App
    {
        public ITodoRepository TodoRepository { get; set; }
        public List<Command> Commands { get; set; }

        public App()
        {
            TodoRepository = new TodoRepository();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            Commands = new List<Command>
            {
                new Command("list", PrintList),
                new Command("rem", PromptRemoveItem),
                new Command("add", PromptNewItem),
                new Command("complete", PromptCompleteItem)
            };

        }

        public async Task RunAsync()
        {
            while (true)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                RunCommand(command);
            }
        }

        public void RunCommand(string commandKey)
        {
            var command = Commands.FirstOrDefault(c => c.Key == commandKey);
            if (command == null)
                return;

            command.Action.Invoke();
        }

        private void PromptCompleteItem()
        {
            Console.WriteLine("ID:");
            var id = Console.ReadLine();

            var item = TodoRepository.GetItem(id);
            item.IsCompleted = true;

            TodoRepository.UpdateItem(item);
            Console.WriteLine("Item was marked as completed.");
        }

        private void PromptRemoveItem()
        {
            Console.WriteLine("ID:");
            var id = Console.ReadLine();

            TodoRepository.RemoveItemById(id);
            Console.WriteLine("Item was successfully removed.");
        }

        private void PromptNewItem()
        {
            var item = new TodoItem();
            
            Console.WriteLine("Title:");
            item.Title = Console.ReadLine();

            Console.WriteLine("Content:");
            item.Content = Console.ReadLine();

            TodoRepository.AddItem(item);
            Console.WriteLine("Item was successfully added.");
        }

        private void PrintList()
        {
            var list = this.TodoRepository.GetAllItems();

            if (list.ToList().Count < 1)
            {
                Console.WriteLine("No items were found.");
                return;
            }

            foreach (TodoItem todoItem in list)
            {
                Console.WriteLine(todoItem);
            }
        }
    }
}