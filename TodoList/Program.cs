using System;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Repositories;

namespace TodoList
{
    class Program
    {
        static void Main(string[] args) => new App().RunAsync().GetAwaiter().GetResult();
    }

    public class App
    {
        public ITodoRepository TodoRepository { get; set; }

        public App()
        {
            TodoRepository = new TodoRepository();
        }

        public async Task RunAsync()
        {
            while (true)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                RunCommand(command);
            }

            // await Task.Delay(-1);
        }

        public void RunCommand(string command)
        {
            switch (command)
            {
                case "list":
                    PrintList();
                    break;
                case "rem":
                    PromptRemoveItem();
                    break;
                case "add":
                    PromptNewItem();
                    break;
                case "complete":
                    PromptCompleteItem();
                    break;
                default:
                    break;
            }
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
