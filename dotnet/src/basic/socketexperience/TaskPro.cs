namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class TaskPro
    {
        static void Main(string[] args)
        {

            Task<string> task = new Task<string>(TaskAction);

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken cancellationToken = source.Token;
            task.Start();
            task.Wait();
           
            System.Console.WriteLine(task.Result);
            Console.WriteLine("Hello TaskPro!");
            Console.ReadKey();

            string searchContent = Console.ReadLine();

            // ¹¹ÔìBingËÑË÷µÄURL  
            string searchUrl = $"https://www.bing.com/search?q={Uri.EscapeDataString(searchContent)}";


        }

        static string TaskAction()
        {
            try
            {
                Console.WriteLine("Action start!");
                Thread.Sleep(10000);
                Console.WriteLine("Action complete!");
                return "result";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return ex.ToString();
            }

        }


    }



}