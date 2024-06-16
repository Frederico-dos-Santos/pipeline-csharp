using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
namespace WebPatient.AcceptanceTest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                       .UseContentRoot(GetProjectPath())
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup<TStartup>();
                       });
        }

        private string GetProjectPath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var projectName = "WebPatient";
            var directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null && !directoryInfo.GetFiles("*.sln").Any())
            {
                directoryInfo = directoryInfo.Parent;
            }

            return Path.Combine(directoryInfo.FullName, projectName);
        }
    }
}
