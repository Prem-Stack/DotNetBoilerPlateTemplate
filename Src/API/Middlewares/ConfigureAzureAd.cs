/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.WebApi.Middlewares;

/// <summary>
/// Helper class for configuring Azure AD authentication in the API.
/// </summary>
public static class ConfigureAzureAd
{
    /// <summary>
    /// Adds Azure AD configuration to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the Azure AD configuration to.</param>
    /// <param name="config">The <see cref="Microsoft.Extensions.Configuration.ConfigurationManager"/> containing the Azure AD configuration.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddAzureAdConfig(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager config)
    {
        // Adds Microsoft Identity platform (Azure AD B2C) support to protect this Api
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(
            options =>
                {
                    config.Bind("AzureAd", options);
                    options.TokenValidationParameters.NameClaimType = "name";
                },
            options => { config.Bind("AzureAd", options); });
        IdentityModelEventSource.ShowPII = true;
        return services;
    }
}
