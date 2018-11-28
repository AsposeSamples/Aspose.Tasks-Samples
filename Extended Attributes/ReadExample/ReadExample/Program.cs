using System;
using System.IO;
using System.Linq;
using Aspose.Tasks;

namespace ReadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TestProject.mpp");

            Project myProject = new Project(filePath);

            
            TaskCollection tasks = myProject.RootTask.Children;

            Task[] serverTasks = tasks.Where(t => t.ExtendedAttributes.Any(ea => ea.TextValue.StartsWith("Server"))).ToArray();

            Task[] clientTasks = tasks.Where(t => t.ExtendedAttributes.Any(ea => ea.TextValue.StartsWith("Client"))).ToArray();


            if (serverTasks.Any())
            {
                Console.WriteLine($"Server Side: {string.Join(", ", serverTasks.Select(t => t.Get(Tsk.Name)))}");
            }

            if (clientTasks.Any())
            {
                Console.WriteLine($"Client Side: {string.Join(", ", clientTasks.Select(t => t.Get(Tsk.Name)))}");
            }

            Console.ReadLine();
        }
    }
}
