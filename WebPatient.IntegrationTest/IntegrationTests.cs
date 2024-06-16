using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
namespace WebPatient.IntegrationTest
{
    public class IntegrationTests
    {
        private HttpClient _client;
        private const string BaseUrl = "/api/WebApi";

        [SetUp]
        public void Setup()
        {
            var factory = new CustomWebApplicationFactory<Startup>();
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:5255")
            });
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public async Task AddPatient_ReturnsSuccessStatusCode()
        {
            // Arrange
            var url = $"{BaseUrl}/Create";
            var newPatient = new Patient
            {
                Nome = "Joaozinho",
                Sobrenome = "Joao",
                Sexo = "M",
                Nascimento = new DateTime(1990, 1, 1),
                Altura = 1.80,
                Peso = 80,
                Cpf = "12345678901"
            };
            var content = new StringContent(JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdPatient = JsonConvert.DeserializeObject<Patient>(responseString);

            Assert.AreNotEqual(Guid.Empty, createdPatient.Id);
        }

        [Test]
        public async Task GetAllPatients_ReturnsSuccessStatusCode()
        {
            var url = $"{BaseUrl}/GetAll";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task UpdatePatient_ReturnsSuccessStatusCode()
        {
            var addUrl = $"{BaseUrl}/Create";
            var newPatient = new Patient
            {
                Nome = "Batatinha",
                Sobrenome = "Inha",
                Sexo = "F",
                Nascimento = new DateTime(1995, 5, 5),
                Altura = 1.65,
                Peso = 60,
                Cpf = "98765432109"
            };
            var addContent = new StringContent(JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json");
            var addResponse = await _client.PostAsync(addUrl, addContent);
            addResponse.EnsureSuccessStatusCode();

            var responseString = await addResponse.Content.ReadAsStringAsync();
            var createdPatient = JsonConvert.DeserializeObject<Patient>(responseString);

            var updateUrl = $"{BaseUrl}/Update/{createdPatient.Id}";
            var updatedPatient = new Patient
            {
                Id = createdPatient.Id,
                Nome = "Mariazinha",
                Sobrenome = "Inha",
                Sexo = "F",
                Nascimento = newPatient.Nascimento,
                Altura = 1.65,
                Peso = 65,
                Cpf = newPatient.Cpf
            };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedPatient), Encoding.UTF8, "application/json");

            var updateResponse = await _client.PutAsync(updateUrl, updateContent);

            updateResponse.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task DeletePatient_ReturnsSuccessStatusCode()
        {
            var addUrl = $"{BaseUrl}/Create";
            var newPatient = new Patient
            {
                Nome = "Laulau",
                Sobrenome = "Nikolau",
                Sexo = "M",
                Nascimento = new DateTime(1980, 3, 15),
                Altura = 1.70,
                Peso = 75,
                Cpf = "11122233344"
            };
            var addContent = new StringContent(JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json");
            var addResponse = await _client.PostAsync(addUrl, addContent);
            addResponse.EnsureSuccessStatusCode();

            var responseString = await addResponse.Content.ReadAsStringAsync();
            var createdPatient = JsonConvert.DeserializeObject<Patient>(responseString);

            var deleteUrl = $"{BaseUrl}/Delete/{createdPatient.Id}";

            var deleteResponse = await _client.DeleteAsync(deleteUrl);

            deleteResponse.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetPatientById_ReturnsCorrectPatient()
        {
            var addUrl = $"{BaseUrl}/Create";
            var newPatient = new Patient
            {
                Nome = "Pai",
                Sobrenome = "Papai",
                Sexo = "F",
                Nascimento = new DateTime(1992, 10, 20),
                Altura = 1.60,
                Peso = 55,
                Cpf = "55566677788"
            };
            var addContent = new StringContent(JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json");
            var addResponse = await _client.PostAsync(addUrl, addContent);
            addResponse.EnsureSuccessStatusCode();

            var responseString = await addResponse.Content.ReadAsStringAsync();
            var createdPatient = JsonConvert.DeserializeObject<Patient>(responseString);

            Assert.AreNotEqual(Guid.Empty, createdPatient.Id);

            var deleteUrl = $"{BaseUrl}/Delete/{createdPatient.Id}";
            var deleteResponse = await _client.DeleteAsync(deleteUrl);
            deleteResponse.EnsureSuccessStatusCode();

            var getUrl = $"{BaseUrl}/GetById/{createdPatient.Id}";
            var getResponse = await _client.GetAsync(getUrl);

            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
        }
    }
}
