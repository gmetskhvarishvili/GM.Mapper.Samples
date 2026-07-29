using System.Reflection;
using GM.Mapper.Sample.Application.People;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace GM.Mapper.Sample.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the sample application: scans this assembly for Mapster mappings
    /// (the <c>IRegister</c> classes) and wires up the in-memory store and people service.
    /// Call <c>services.AddGMMapper()</c> (from the GM.Mapper package) alongside this.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<IPeopleStore, InMemoryPeopleStore>();
        services.AddScoped<IPeopleService, PeopleService>();

        return services;
    }
}
