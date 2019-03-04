using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Repositories;

namespace TodoList
{
    /// <summary>
    /// This class bootstraps the whole application and makes it executable
    /// </summary>
    public class App
    {
        public ITodoRepository TodoRepository { get; set; }
        public List<Command> Commands { get; set; }

        public App()
        {
            // Syntax error on purpose
            TodoRepository = new TodoRepository()
            InitializeCommands();
        }

        /// <summary>
        /// Initializes and adds repository commands to the application
        /// </summary>
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

        /// <summary>
        /// Starts the command reader loop and executes them
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            while (true)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                RunCommand(command);
            }
        }

        /// <summary>
        /// Runs a command by its key
        /// </summary>
        /// <param name="commandKey"></param>
        public void RunCommand(string commandKey)
        {
            var command = Commands.FirstOrDefault(c => c.Key == commandKey);
            if (command == null)
            {
                Console.WriteLine("Command not found.");
                return;
            }

            command.Execute();
        }

        /// <summary>
        /// Asks the user to mark one item as complete
        /// </summary>
        private void PromptCompleteItem()
        {
            Console.WriteLine("ID:");
            var id = Console.ReadLine();

            var item = TodoRepository.GetItem(id);
            item.IsCompleted = true;

            TodoRepository.UpdateItem(item);
            Console.WriteLine("Item was marked as completed.");
        }

        /// <summary>
        /// Prompts the user to remove an item by its ID
        /// </summary>
        private void PromptRemoveItem()
        {
            Console.WriteLine("ID:");
            var id = Console.ReadLine();

            TodoRepository.RemoveItemById(id);
            Console.WriteLine("Item was successfully removed.");
        }

        /// <summary>
        /// Lets the user create a new item
        /// </summary>
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

        /// <summary>
        /// Prints all items to the console
        /// </summary>
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