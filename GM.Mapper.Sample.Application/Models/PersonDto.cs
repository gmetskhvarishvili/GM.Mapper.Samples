namespace GM.Mapper.Sample.Application.Models;

/// <summary>
/// The projection returned to clients. <c>FullName</c> and <c>Age</c> are computed from the
/// <see cref="Person"/> during mapping (see MappingRegister).
/// </summary>
public sealed record PersonDto
{
    public Guid Id { get; init; }
    public string FullName { get; init; } = string.Empty;
    public int Age { get; init; }
    public string Email { get; init; } = string.Empty;
}
