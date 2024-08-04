/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAzureAppConfig(builder);
builder.Services.AddSeriLogConfig(builder);
builder.Services.AddCustomSwaggerParameter();
// builder.Services.AddAzureAdConfig(builder.Configuration);
builder.Services.AddHttpClientPolly();
builder.Services.AddApiVersioningConfig();
builder.Services.AddHealthCheckServiceConfig();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseSwagger();
app.UseAzureAppConfiguration();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapHealthChecks("api/health");
app.MapControllers();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerUI(options =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});
app.Run();
