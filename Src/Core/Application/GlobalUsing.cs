/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

global using System.Net;
global using System.Reflection;
global using System.Text.Json;
global using AutoMapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.Data.SqlClient;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Template.Application.Exceptions;
global using Template.Application.Wrappers;
global using Template.Domain.Common;
global using Template.Domain.Entities;
global using Template.Infrastructure;
global using static Template.Infrastructure.Common.CommonEnum;
global using Template.Application.Behaviours;
global using Template.Infrastructure.Repositories.Users;
global using Template.Infrastructure.Common;