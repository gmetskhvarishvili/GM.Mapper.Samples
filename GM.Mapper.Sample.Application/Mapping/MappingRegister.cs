using GM.Mapper.Sample.Application.Models;
using Mapster;

namespace GM.Mapper.Sample.Application.Mapping;

/// <summary>
/// Custom Mapster mappings, discovered by <c>TypeAdapterConfig.Scan(...)</c>. Shows computing
/// derived fields (<c>FullName</c>, <c>Age</c>) instead of just copying matching properties.
/// </summary>
public sealed class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Person, PersonDto>()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.Age, src => AgeInYears(src.DateOfBirth));

        // CreatePersonRequest -> Person: matching names map automatically; Id keeps its generated value.
        config.NewConfig<CreatePersonRequest, Person>();
    }

    private static int AgeInYears(DateOnly dateOfBirth)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - dateOfBirth.Year;
        if (dateOfBirth > today.AddYears(-age))
            age--;
        return age;
    }
}
