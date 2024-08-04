/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.WebApi.Controllers.Users.V1;

/// <summary>
/// Represents the controller for managing user operations.
/// </summary>
[ApiVersion("1.0")]
//[Authorize]
public class UserController : VersionedApiController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator instance.</param>
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Fetches all user data from the database using Mediator.
    /// </summary>
    /// <returns>Returns all the user details through the response model.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Version 1");
    }
}
