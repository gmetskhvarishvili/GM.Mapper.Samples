namespace GM.Mapper.Sample.Application.Models;

/// <summary>Inbound model for creating a person; mapped to <see cref="Person"/>.</summary>
public sealed record CreatePersonRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public required string Email { get; init; }
}
