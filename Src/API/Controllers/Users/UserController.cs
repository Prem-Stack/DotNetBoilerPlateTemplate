/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.WebApi.Controllers.Users;

/// <summary>
/// Controller class for managing user operations.
/// </summary>
// [Authorize]
public class UserController : BaseController
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
    /// Insert User data into database using Mediator.
    /// </summary>
    /// <param name="user">Post Request data.</param>
    /// <returns>It will return Inserted User details through the response model.</returns>
    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        return this.Ok(await this._mediator.Send(new CreateUserCommand(user)));
    }

    /// <summary>
    /// Update the user data into database using Mediator.
    /// </summary>
    /// <param name="user">Input data.</param>
    /// <returns>It will return Updated User details through the response model.</returns>
    [HttpPut]
    public async Task<IActionResult> Put(User user)
    {
        return this.Ok(await this._mediator.Send(new CreateUserCommand(user)));
    }

    /// <summary>
    /// Fetch all User data from database using Mediator.
    /// </summary>
    /// <returns>It will return All the User details through the response model.</returns>
    [HttpGet("~/api/Users")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await this._mediator.Send(new GetAllUsersQuery()));
    }

    /// <summary>
    /// Fetch User from database based on given id using Mediator.
    /// </summary>
    /// <param name="id">Input id.</param>
    /// <returns>It will return User details of the given Id through the response model.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return this.Ok(await this._mediator.Send(new GetByIdUserQuery(id)));
    }

    /// <summary>
    /// Delete the given user id data from database using Mediator.
    /// </summary>
    /// <param name="id">input id.</param>
    /// <returns>It will return the Success Message.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return this.Ok(await this._mediator.Send(new DeleteUserCommand(id)));
    }
}
