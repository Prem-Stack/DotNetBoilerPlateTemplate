/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
global using System.Data;
global using System.Data.Common;
global using System.Reflection;
global using MediatR;
global using Microsoft.DotNet.PlatformAbstractions;
global using Microsoft.Extensions.Options;
global using Moq;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Linq;
global using Template.Application.Handlers.Users.Commands;
global using Template.Application.Handlers.Users.Queries;
global using Template.Application.Handlers.Users.Validator;
global using Template.Application.Wrappers;
global using Template.Domain.Common;
global using Template.Domain.Entities;
global using Template.Infrastructure.Repositories.Users;
global using Template.UnitTests.CommonHelper;
global using Template.UnitTests.MockData;
global using Xunit;
global using Xunit.Sdk;
global using Template.Infrastructure.Common;
