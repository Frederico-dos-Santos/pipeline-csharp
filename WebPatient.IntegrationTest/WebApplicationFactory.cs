using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace WebPatient.IntegrationTest
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Configurar e registrar serviços necessários para os testes de integração
                services.AddHttpClient();
                // outros serviços necessários podem ser adicionados aqui
            });
        }
    }
}
