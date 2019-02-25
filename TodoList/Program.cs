using System;
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
        public TodoRepository TodoRepository { get; set; }

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
                    default:
                        break;
                }
            }
            await Task.Delay(-1);
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
            foreach (TodoItem todoItem in list)
            {
                Console.WriteLine(todoItem);
            }
        }
    }
}
