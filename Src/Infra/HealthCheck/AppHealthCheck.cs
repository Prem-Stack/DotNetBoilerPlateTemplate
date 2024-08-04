/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure.HealthCheck;

/// <summary>
/// AppHealthCheck class to validate the app is healthy.
/// </summary>
public class AppHealthCheck : IHealthCheck
{
    /// <summary>
    /// AppHealthCheck class to validate the app is healthy.
    /// </summary>
    /// <param name="context">Health Check Context.</param>
    /// <param name="cancellationToken">Oearation cancel.</param>
    /// <returns>It will return the App is healthy or not.</returns>
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        bool isHealthy = true;

        // TODO: Add Logic to check DB and 3rd party connetions to show that the system is working.
        if (isHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy(Constant.Healthy));
        }

        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, Constant.UnHealthy));
    }
}
