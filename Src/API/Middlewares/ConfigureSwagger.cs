/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.WebApi.Middlewares;

/// <summary>
/// Helper class for configuring Swagger.
/// </summary>
public static class ConfigureSwagger
{
    /// <summary>
    /// Adds a custom Swagger parameter to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the custom Swagger parameter to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddCustomSwaggerParameter(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition(Constant.Bearer, new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = string.Empty,
                Name = Constant.Authorization,
                Type = SecuritySchemeType.Http,
                BearerFormat = Constant.JWT,
                Scheme = Constant.Bearer
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id =  Constant.Bearer
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}
