using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api3
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();

        }
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
        }
    }
}
