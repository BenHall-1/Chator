using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Chator.Server
{
    /// <summary>
    /// Main Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main program method.
        /// </summary>
        /// <param name="args">Args to be passed into the program.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The main way to create the HostBuilder.
        /// </summary>
        /// <param name="args">The args to build the HostBuilder with.</param>
        /// <returns>A HostBuilder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
