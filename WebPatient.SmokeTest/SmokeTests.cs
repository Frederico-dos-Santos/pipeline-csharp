using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using WebPatient;
using Xunit;

public class SmokeTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public SmokeTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.UseSolutionRelativeContentRoot("WebPatient"); 
        });
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
