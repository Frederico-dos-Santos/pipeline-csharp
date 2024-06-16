using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
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

        var response = await client.GetAsync("/api/WebApi/GetAll");

        response.EnsureSuccessStatusCode(); 
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
