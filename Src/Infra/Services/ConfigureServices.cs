/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure.Services;

/// <summary>
/// ConfigureServices a collection of service descriptors.
/// </summary>
/// <remarks>
/// The IServiceCollection interface is used to configure and register services in the dependency injection container.
/// </remarks>
public static class ConfigureServices
{
    /// <summary>
    /// AddAzureAppConfig a collection of service descriptors.
    /// </summary>
    /// <param name="services">ServiceCollection interface is used to configure and register services in the dependency injection.</param>
    /// <param name="builder">Web Application Builder.</param>
    /// <returns>Service Collection Modified.</returns>
    public static IServiceCollection AddAzureAppConfig(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Configuration.AddAzureAppConfiguration(options =>
        {
            // Connection azure app configuration
            options.Connect(builder.Configuration.GetConnectionString(Constant.AppConfigConn))

            // If non production Environment is Set app registration Credential
            .ConfigureKeyVault(kv =>
            {
                // kv.SetCredential(new DefaultAzureCredential());

                 // If you want run local use the code.
                 _ = builder.Environment.IsDevelopment() ?
                    kv.SetCredential(new ClientSecretCredential(
                    builder.Configuration.GetConnectionString(Constant.TenantId),
                    builder.Configuration.GetConnectionString(Constant.ClientId),
                    builder.Configuration.GetConnectionString(Constant.ClientSecret)))
                 : kv.SetCredential(new DefaultAzureCredential());
            });
            options.ConfigureRefresh(refresh =>
                refresh
                    .Register("FNP:Version", refreshAll: true));
        }).Build();
        services.Configure<AppSettings>(builder.Configuration.GetSection("FNP:Settings"));
        services.AddAzureAppConfiguration();
        return services;
    }
}
