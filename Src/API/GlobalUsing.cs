/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
global using System.Net;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;
global using Microsoft.Data.SqlClient;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using Polly.CircuitBreaker;
global using Serilog;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using Template.Application;
global using Template.Application.Exceptions;
global using Template.Application.Handlers.Users.Commands;
global using Template.Application.Handlers.Users.Queries;
global using Template.Application.Wrappers;
global using Template.Domain.Entities;
global using Template.Infrastructure;
global using Template.Infrastructure.Common;
global using Template.Infrastructure.Common.Logger;
global using Template.Infrastructure.Services;
global using Template.WebApi.Middlewares;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Identity.Web;
global using Microsoft.IdentityModel.Logging;
