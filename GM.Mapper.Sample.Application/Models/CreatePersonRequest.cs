namespace GM.Mapper.Sample.Application.Models;

/// <summary>Inbound model for creating a person; mapped to <see cref="Person"/>.</summary>
public class CreatePersonRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required string Email { get; set; }
}
