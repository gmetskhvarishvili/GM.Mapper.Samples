using GM.Mapper.Sample.Application.Models;

namespace GM.Mapper.Sample.Application.People;

/// <summary>A trivial in-memory store so the sample runs with no database.</summary>
public interface IPeopleStore
{
    void Add(Person person);
    IReadOnlyList<Person> GetAll();
}

public sealed class InMemoryPeopleStore : IPeopleStore
{
    private readonly List<Person> _people = [];
    private readonly Lock _gate = new();

    public void Add(Person person)
    {
        lock (_gate)
            _people.Add(person);
    }

    public IReadOnlyList<Person> GetAll()
    {
        lock (_gate)
            return _people.ToList();
    }
}
