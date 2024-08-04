/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.WebApi.Controllers;

/// <summary>
/// VersionedApiController a base controller for versioned APIs.
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
public class VersionedApiController : BaseController
{
}
