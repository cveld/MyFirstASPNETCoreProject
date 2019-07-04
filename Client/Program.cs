using System;
using System.Net.Http;

namespace Client
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var httpClient = new HttpClient();
            var todoClient = new TodoClient(httpClient);
            // Gets all to-dos from the API
            var allTodos = await todoClient.GetTodoItemsAsync();

            // Create a new TodoItem, and save it via the API.
            var createdTodo = await todoClient.PostTodoItemAsync(new TodoItem());

            // Get a single to-do by ID
            var foundTodo = await todoClient.GetTodoItemAsync(1);
        }
    }
}
