using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using WebPatient;

namespace WebPatient.IntegrationTest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<PatientContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<PatientContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<PatientContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }

        private void InitializeDbForTests(PatientContext db)
        {
            db.Patients.AddRange(
                new Patient
                {
                    Id = Guid.NewGuid(),
                    Nome = "John",
                    Sobrenome = "Doe",
                    Cpf = "12345678901",
                    Nascimento = new DateTime(1990, 1, 1),
                    Sexo = "M",
                    Altura = 180,
                    Peso = 75.5
                },
                new Patient
                {
                    Id = Guid.NewGuid(),
                    Nome = "Jane",
                    Sobrenome = "Doe",
                    Cpf = "09876543210",
                    Nascimento = new DateTime(1992, 2, 2),
                    Sexo = "F",
                    Altura = 165,
                    Peso = 65.0
                }
            );

            db.SaveChanges();
        }
    }
}
