using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using WebPatient;

public class WebApiAcceptanceTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public WebApiAcceptanceTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            var contentRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "WebPatient");
            builder.UseContentRoot(contentRoot);
        });
    }

    [Fact]
    public async Task CreatePatient_ReturnsCreated()
    {
        var client = _factory.CreateClient();
        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            Nome = "Pedro",
            Sobrenome = "Pe",
            Sexo = "M",
            Nascimento = new DateTime(1990, 1, 1),
            Altura = 161,
            Peso = 75,
            Cpf = "12345678901"
        };

        var content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/WebApi/Create", content);

        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GetAllPatients_ReturnsPatients()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/WebApi/GetAll");

        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(responseString);

        Assert.NotNull(patients);
    }

    [Fact]
    public async Task GetPatientById_ReturnsPatient()
    {
        var client = _factory.CreateClient();
        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            Nome = "Ana",
            Sobrenome = "Annna",
            Sexo = "F",
            Nascimento = new DateTime(1985, 5, 15),
            Altura = 140,
            Peso = 65,
            Cpf = "98765432101"
        };

        var createContent = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
        await client.PostAsync("/api/WebApi/Create", createContent);

        var response = await client.GetAsync($"/api/WebApi/GetById/{patient.Id}");

        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var returnedPatient = JsonConvert.DeserializeObject<Patient>(responseString);

        Assert.NotNull(returnedPatient);
        Assert.Equal(patient.Id, returnedPatient.Id);
    }

    [Fact]
    public async Task UpdatePatient_ReturnsNoContent()
    {
        var client = _factory.CreateClient();
        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            Nome = "Update",
            Sobrenome = "Me",
            Sexo = "M",
            Nascimento = new DateTime(1992, 2, 2),
            Altura = 175,
            Peso = 70,
            Cpf = "11223344556"
        };

        var createContent = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
        await client.PostAsync("/api/WebApi/Create", createContent);

        patient.Nome = "Updated";
        var updateContent = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"/api/WebApi/Update/{patient.Id}", updateContent);

        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task DeletePatient_ReturnsNoContent()
    {
        var client = _factory.CreateClient();
        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            Nome = "Delete",
            Sobrenome = "Me",
            Sexo = "F",
            Nascimento = new DateTime(1995, 5, 5),
            Altura = 165,
            Peso = 60,
            Cpf = "99887766554"
        };

        var createContent = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
        await client.PostAsync("/api/WebApi/Create", createContent);

        var response = await client.DeleteAsync($"/api/WebApi/Delete/{patient.Id}");

        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }
}
