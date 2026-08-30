using GM.Mapper.Sample.Application.Models;
using GM.Mapper.Sample.Application.People;
using Microsoft.AspNetCore.Mvc;

namespace GM.Mapper.Sample.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class PeopleController(IPeopleService people) : ControllerBase
{
    /// <summary>Returns all people as mapped DTOs (FullName + Age computed during mapping).</summary>
    [HttpGet]
    public IActionResult GetAll() => Ok(people.GetAll());

    /// <summary>Creates a person from the request (mapped to the domain entity) and returns its DTO.</summary>
    [HttpPost]
    public IActionResult Create([FromBody] CreatePersonRequest request) => Ok(people.Create(request));
}
