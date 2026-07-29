using GM.Mapper.Sample.Application.Mapping;
using GM.Mapper.Sample.Application.Models;
using Mapster;
using MapsterMapper;
using Xunit;

namespace GM.Mapper.Sample.Tests;

public class MappingTests
{
    private static IMapper CreateMapper()
    {
        var config = new TypeAdapterConfig();
        config.Scan(typeof(MappingRegister).Assembly);
        return new MapsterMapper.Mapper(config);
    }

    [Fact]
    public void Person_maps_to_dto_with_computed_full_name_and_age()
    {
        var dob = DateOnly.FromDateTime(DateTime.UtcNow).AddYears(-30);
        var person = new Person
        {
            FirstName = "Ada",
            LastName = "Lovelace",
            DateOfBirth = dob,
            Email = "ada@example.com"
        };

        var dto = CreateMapper().Map<PersonDto>(person);

        Assert.Equal(person.Id, dto.Id);
        Assert.Equal("Ada Lovelace", dto.FullName);
        Assert.Equal(30, dto.Age);
        Assert.Equal("ada@example.com", dto.Email);
    }

    [Fact]
    public void Create_request_maps_to_person_with_a_generated_id()
    {
        var request = new CreatePersonRequest
        {
            FirstName = "Grace",
            LastName = "Hopper",
            DateOfBirth = new DateOnly(1906, 12, 9),
            Email = "grace@example.com"
        };

        var person = CreateMapper().Map<Person>(request);

        Assert.Equal("Grace", person.FirstName);
        Assert.Equal("Hopper", person.LastName);
        Assert.Equal("grace@example.com", person.Email);
        Assert.NotEqual(Guid.Empty, person.Id);
    }
}
