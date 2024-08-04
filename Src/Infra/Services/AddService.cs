/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Infrastructure.Services;

/// <summary>
/// Provides methods to configure services related to health checks.
/// </summary>
public static class AddService
{
    /// <summary>
    /// Add the Health Check Class.
    /// </summary>
    /// <param name="services">Service Collection.</param>
    /// <returns>return service.</returns>
    public static IServiceCollection AddHealthCheckServiceConfig(this IServiceCollection services)
    {
        services.AddHealthChecks().AddCheck<AppHealthCheck>("App Health Check", null, new[] { "Service" });
        services.AddTransient(typeof(AppHealthCheck));
        return services;
    }
}
