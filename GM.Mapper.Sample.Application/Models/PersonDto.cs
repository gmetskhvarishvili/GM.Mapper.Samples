namespace GM.Mapper.Sample.Application.Models;

/// <summary>
/// The projection returned to clients. <c>FullName</c> and <c>Age</c> are computed from the
/// <see cref="Person"/> during mapping (see MappingRegister).
/// </summary>
public class PersonDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;
}
