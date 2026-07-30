<p align="center">
  <img src="icon.png" alt="GM.Mapper Samples" width="140" height="140" />
</p>

# GM.Mapper Samples

[![CI](https://github.com/gmetskhvarishvili/GM.Mapper.Samples/actions/workflows/ci.yml/badge.svg)](https://github.com/gmetskhvarishvili/GM.Mapper.Samples/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

A small ASP.NET Core Web API showing how to use **[GM.Mapper](https://www.nuget.org/packages/GM.Mapper)**
(a thin, DI-friendly wrapper over [Mapster](https://github.com/MapsterMapper/Mapster)) to map domain
entities to DTOs — including **computed fields** via a custom mapping config. Targets **.NET 10**.

## What it demonstrates

- **One-line setup** — `services.AddGMMapper()` registers Mapster's `IMapper`.
- **Custom mappings** — a `MappingRegister : IRegister` maps `Person` → `PersonDto`, computing
  `FullName` and `Age` instead of just copying matching properties.
- **Injecting `IMapper`** into an application service (`PeopleService`) that maps both ways
  (`CreatePersonRequest` → `Person`, `Person` → `PersonDto`).
- **Thin controllers** — the API just calls the service and returns DTOs.

## Project structure

```
GM.Mapper.Sample.API/           # Web API (Program, PeopleController)
GM.Mapper.Sample.Application/    # models, MappingRegister, in-memory store, PeopleService, DI
tests/GM.Mapper.Sample.Tests/    # mapping + service unit tests, and an in-memory API test
```

## Running

```bash
dotnet run --project GM.Mapper.Sample.API
```

Open the Swagger UI, then:

| Method | Route | Body | Result |
| --- | --- | --- | --- |
| `POST` | `/people` | `{ "firstName": "Ada", "lastName": "Lovelace", "dateOfBirth": "1990-01-01", "email": "ada@example.com" }` | `200` + the mapped `PersonDto` |
| `GET` | `/people` | — | `200` + all people as DTOs (with `FullName` + `Age`) |

```bash
curl -k -X POST https://localhost:7000/people \
  -H "Content-Type: application/json" \
  -d '{ "firstName": "Ada", "lastName": "Lovelace", "dateOfBirth": "1990-01-01", "email": "ada@example.com" }'
```

## Testing

```bash
dotnet test
```

Covers the mapping config, the service, and the endpoints end to end via `WebApplicationFactory`
(no external dependencies — the store is in-memory).

## License

MIT — see [LICENSE](LICENSE).
