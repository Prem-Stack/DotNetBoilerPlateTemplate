/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Data;
global using System.Reflection;
global using System.Text;
global using Azure.Identity;
global using Microsoft.ApplicationInsights.Extensibility;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Data.SqlClient;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Serilog;
global using Serilog.Formatting.Compact;
global using Template.Domain.Common;
global using Template.Domain.Entities;
global using Template.Infrastructure.Common;
global using Template.Infrastructure.HealthCheck;
global using Polly;
global using Template.Infrastructure;
global using Template.Infrastructure.StoredProcedure;
global using static Template.Infrastructure.Common.CommonEnum;
