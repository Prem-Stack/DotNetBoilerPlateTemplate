/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure.Common;

/// <summary>
/// Helper class for implementing retry and circuit breaker policies.
/// </summary>
public static class RetryHelper
{
    /// <summary>
    /// Represents a lazy-initialized policy that combines retry and circuit breaker policies.
    /// </summary>
    private static readonly Lazy<Policy> _retryAndCircuitBreakerPolicy =
        new Lazy<Policy>(() =>
        {
            var retryPolicy = Policy.Handle<SqlException>().Or<TimeoutException>()
                    .WaitAndRetry(
                    retryCount: Constant.RetryCount,
                    sleepDurationProvider: attempt => TimeSpan.FromSeconds(Constant.SleepDurationProvider),
                    onRetry: (exception, timespan, retryAttempt, context) =>
                    {
                        Log.Information($"Retry attempt {retryAttempt} due to DB exception");
                    });

            var circuitBreakerPolicy = Policy.Handle<SqlException>().Or<TimeoutException>()
                .CircuitBreaker(
                    exceptionsAllowedBeforeBreaking: Constant.CircuitBreakerOpenCount,
                    durationOfBreak: TimeSpan.FromSeconds(Constant.CircuitBreakDuration),
                    onBreak: (exception, timespan) =>
                    {
                        Log.Error($"Error occurred due to DB exception", exception);
                    },
                    onReset: () =>
                    {
                        Log.Information("DB Exception is operational.");
                    });

            return Policy.Wrap(retryPolicy, circuitBreakerPolicy);
        });

    /// <summary>
    /// Executes the specified action with a retry and circuit breaker policy.
    /// </summary>
    /// <param name="action">The action to be executed.</param>
    public static void RetryAndCircuitBreakerPolicy(System.Action action)
    {
        try
        {
            _retryAndCircuitBreakerPolicy.Value.Execute(action);
        }
        catch (SqlException ex)
        {
            Log.Error(ex.Message);
        }
    }

    /// <summary>
    /// Adds HttpClient Polly policies for circuit breaking and retrying.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the policies to.</param>
    /// <returns>The modified IServiceCollection.</returns>
    public static IServiceCollection AddHttpClientPolly(this IServiceCollection services)
    {
        // Circuit breaking using polly
        _ = services.AddHttpClient("errorApi", c => { c.BaseAddress = new Uri(string.Empty); })
            .AddTransientHttpErrorPolicy(policy =>
            {
                static void OnBreak(DelegateResult<HttpResponseMessage> ex, TimeSpan timeSpan)
                {
                    throw new HttpRequestException(Constant.CircuitError);
                }

                return policy.CircuitBreakerAsync(Constant.CircuitBreakerOpenCount, TimeSpan.FromSeconds(Constant.DurationOfBreak), OnBreak, () => { });
            });

        // Retry using polly
        services.AddHttpClient("errorApiClient", c => { c.BaseAddress = new Uri(string.Empty); })
               .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(Constant.RetryCount, _ => TimeSpan.FromSeconds(Constant.SleepDurationProvider)));

        return services;
    }
}
