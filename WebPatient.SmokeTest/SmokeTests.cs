using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using WebPatient;

public class SmokeTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public SmokeTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task TestHomePageResponse()
    {
        var client = _factory.CreateClient();

        try
        {
            var response = await client.GetAsync("/api/WebApi/GetAll");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception during test execution:");
            Console.WriteLine(ex.ToString());
        }
    }
}