/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure.Common.Logger;

/// <summary>
/// Provides methods to configure logging for the application.
/// </summary>
public static class LoggingConfig
{
    /// <summary>
    /// Extension method to add SeriLog configuration to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the SeriLog configuration to.</param>
    /// <param name="builder">The WebApplicationBuilder used to retrieve configuration values.</param>
    /// <returns>The modified IServiceCollection.</returns>
    public static IServiceCollection AddSeriLogConfig(this IServiceCollection services, WebApplicationBuilder builder)
    {
        string? instrumentationKey = builder.Configuration.GetSection(Constant.InstrumentationKey).Value;
        string? workspaceId = builder.Configuration.GetSection(Constant.LogAnalyticsWorkSpaceId).Value;
        string? sharedKey = builder.Configuration.GetSection(Constant.LogAnalyticsSharedKey).Value;

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.WithProperty("ApplicationName", Constant.LogName)
            .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = instrumentationKey }, TelemetryConverter.Traces)
            .WriteTo.Console(new CompactJsonFormatter())
            .CreateLogger();

        builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration)
                .Enrich.WithProperty("ApplicationName", Constant.LogName)
                .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = instrumentationKey }, TelemetryConverter.Traces)
                .WriteTo.Console(new CompactJsonFormatter());
        });
        return services;
    }
}