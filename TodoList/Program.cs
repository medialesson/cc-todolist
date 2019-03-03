namespace TodoList
{
    class Program
    {
        static void Main(string[] args) => new App().RunAsync().GetAwaiter().GetResult();
    }
}
