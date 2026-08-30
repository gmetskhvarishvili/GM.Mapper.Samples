using GM.Mapper.Sample.Application.Models;
using MapsterMapper;

namespace GM.Mapper.Sample.Application.People;

/// <summary>Application service that maps between domain entities and DTOs via the injected mapper.</summary>
public interface IPeopleService
{
    IReadOnlyList<PersonDto> GetAll();
    PersonDto Create(CreatePersonRequest request);
}

public sealed class PeopleService(IMapper mapper, IPeopleStore store) : IPeopleService
{
    public IReadOnlyList<PersonDto> GetAll() =>
        store.GetAll().Select(mapper.Map<PersonDto>).ToList();

    public PersonDto Create(CreatePersonRequest request)
    {
        var person = mapper.Map<Person>(request);
        store.Add(person);
        return mapper.Map<PersonDto>(person);
    }
}
