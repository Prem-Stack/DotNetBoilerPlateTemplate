/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Infrastructure.Common;

/// <summary>
///  All the common values are stored here.
/// </summary>
public static class Constant
{
    public const int RetryCount = 2; // This is default Retry Count. If dynamic retry counts are needed, consider using Key Vault.
    public const int CircuitBreakerOpenCount = 2; // This is default CircuitBreakerOpenCount. If dynamic retry counts are needed, consider using Key Vault.
    public const double CircuitBreakDuration = 30; // This is default CircuitBreakDuration. If dynamic retry counts are needed, consider using Key Vault.
    public const double DurationOfBreak = 5; // This is default DurationOfBreak. If dynamic retry counts are needed, consider using Key Vault.
    public const double SleepDurationProvider = 2; // This is default SleepDurationProvider. If dynamic retry counts are needed, consider using Key Vault.
    public const string Authorization = "Authorization";
    public const string Bearer = "bearer";
    public const string JWT = "JWT";
    public const string AppSetting = "FNP:Settings:";
    public const string SQLConnectionString = $"{AppSetting}SQLConnectionString";
    public const string InvalidDb = "Invalid DB Operation";
    public const string OutOfMemory = "Out of Memory";
    public const string UnAuthorizedAccess = "Unauthorized Access";
    public const string DataNotFound = "Data Not Found";
    public const string AppConfigConn = "AppConfigConn";
    public const string TenantId = "AzureAdTenantId";
    public const string ClientId = "keyvaultclientId";
    public const string ClientSecret = "keyvaultclientSecret";
    public const string LogWorkSpaceId = "LogWorkspaceId";
    public const string LogAuthenticationId = "LogAuthenticationId";
    public const string TemplateLog = "TemplateLog";
    public const string CircuitError = "Circuit broken! Please try again later.";
    public const string ServiceBusConn = "ServiceBusConn";
    public const string ServiceBusTopic = "appconfigurationtopic";
    public const string ServiceBusSubscription = "AppConfigurationSubscription";
    public const string Healthy = "A healthy result.";
    public const string UnHealthy = "An unhealthy result.";
    public const string ContentType = "application/json";
    public const string ErrorMessage = "Error Occurred";
    public const string InsertSuccessMessage = "Inserted Successfully";
    public const string UpdateSuccessMessage = "Updated Successfully";
    public const string DeleteSuccessMessage = "Deleted Successfully";
    public const string UserlengthValidation = "Length should be below 12";
    public const string CommonValidationError = "One or more validation failures have occurred.";

    #region AppInsight
    public const string LogAnalyticsWorkSpaceId = $"{AppSetting}LogAnalyticsWorkSpaceId";
    public const string LogAnalyticsSharedKey = $"{AppSetting}LogAnalyticsSharedKey";
    public const string InstrumentationKey = $"{AppSetting}AppInsightsKey";
    public const string LogName = "BackOffice-RestApi";
    #endregion

    #region Polly
    public const string RetryCountSettings = $"{AppSetting}RetryCount";
    public const string CircuitBreakerOpenCountSettings = $"{AppSetting}CircuitBreakerOpenCount";
    public const string CircuitBreakDurationSettings = $"{AppSetting}CircuitBreakDuration";
    public const string BrokenCircuitException = "Error occurred while processing your request.";
    #endregion
}