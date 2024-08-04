/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.WebApi.Controllers.Users.V2;

// [Authorize]

/// <summary>
/// Represents a controller for managing user operations in version 2.0 of the API.
/// </summary>
[ApiVersion("2.0")]
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
    /// Retrieves all users.
    /// </summary>
    /// <returns>Returns the response with the message "Version 2".</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Version 2");
    }
}
