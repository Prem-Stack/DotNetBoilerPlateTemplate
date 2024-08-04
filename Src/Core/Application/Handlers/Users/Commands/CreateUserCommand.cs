/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Handlers.Users.Commands;

/// <summary>
/// To Insert User Record into DB
/// </summary>
/// <param name="User"></param>
public record CreateUserCommand(User User)
    : IRequest<User>
{
}

/// <summary>
/// Handles the CreateUserCommand by inserting the user data into the database and returning the inserted user details.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    private readonly IResponseData<User>? _response;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="response">The response data.</param>
    public CreateUserCommandHandler(IUserRepository userRepository, IResponseData<User>? response)
    {
        _userRepository = userRepository;
        _response = response;
    }

    /// <summary>
    /// Handles the CreateUserCommand by inserting the user into the data base and returning the created user.
    /// </summary>
    /// <param name="request">The CreateUserCommand request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created user.</returns>
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.InsertAsync(request.User);
        return _response!.ActionResponse(user!) !;
    }
}