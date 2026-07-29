using System.Net;
using System.Net.Http.Json;
using GM.Mapper.Sample.Application.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GM.Mapper.Sample.Tests;

/// <summary>
/// Boots the real API in-memory and exercises the endpoints end to end: model binding ->
/// service -> mapper -> DTO. The in-memory store is a singleton, so POST then GET sees the data.
/// </summary>
public class PeopleEndpointsTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Post_then_get_returns_the_created_person()
    {
        var post = await _client.PostAsJsonAsync("/people", new
        {
            firstName = "Ada",
            lastName = "Lovelace",
            dateOfBirth = "1990-01-01",
            email = "ada@example.com"
        });

        Assert.Equal(HttpStatusCode.OK, post.StatusCode);
        var created = await post.Content.ReadFromJsonAsync<PersonDto>();
        Assert.Equal("Ada Lovelace", created!.FullName);

        var list = await _client.GetFromJsonAsync<List<PersonDto>>("/people");
        Assert.NotNull(list);
        Assert.Contains(list!, p => p.Id == created.Id && p.FullName == "Ada Lovelace");
    }
}
