using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace hello_testcontainers.tests;
public class HelloWorldTestcontainers
{
    [Fact]
    public async Task HelloTestcontainersAsync()
    {
        var gettingStartedContainerBuilder = new TestcontainersBuilder<TestcontainersContainer>()
            .WithImage("docker/getting-started")
            .WithName("HelloWorld");

        await using var test = gettingStartedContainerBuilder.Build();
        await test.StartAsync();
        var x = 1; // Just to add a breakpoint here, to pause execution
    }

    [Fact]
    public async Task HelloWeatherApi()
    {
        var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();
        var response = await client.GetAsync("weatherforecast");
        var content = await response.Content.ReadAsStringAsync();
    }
}
