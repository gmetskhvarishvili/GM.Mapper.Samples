using GM.Mapper.Sample.Application.Mapping;
using GM.Mapper.Sample.Application.Models;
using GM.Mapper.Sample.Application.People;
using Mapster;
using MapsterMapper;
using Xunit;

namespace GM.Mapper.Sample.Tests;

public class PeopleServiceTests
{
    private static PeopleService CreateService()
    {
        var config = new TypeAdapterConfig();
        config.Scan(typeof(MappingRegister).Assembly);
        return new PeopleService(new MapsterMapper.Mapper(config), new InMemoryPeopleStore());
    }

    [Fact]
    public void Create_then_GetAll_returns_the_mapped_person()
    {
        var service = CreateService();

        var created = service.Create(new CreatePersonRequest
        {
            FirstName = "Ada",
            LastName = "Lovelace",
            DateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow).AddYears(-30),
            Email = "ada@example.com"
        });

        Assert.Equal("Ada Lovelace", created.FullName);
        Assert.Equal(30, created.Age);

        var all = service.GetAll();
        Assert.Single(all);
        Assert.Equal(created.Id, all[0].Id);
    }
}
