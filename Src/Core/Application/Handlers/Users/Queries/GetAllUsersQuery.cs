/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Handlers.Users.Queries;

/// <summary>
/// To Fetch the All the User Details.
/// </summary>
public record GetAllUsersQuery : IRequest<User>
{
}

/// <summary>
/// Handles the GetAllUsersQuery and retrieves all user data.
/// </summary>
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, User>
{
    private readonly IUserRepository _userRepository;
    private readonly IResponseData<User>? _response;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllUsersQueryHandler"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="response">The response data.</param>
    public GetAllUsersQueryHandler(IUserRepository userRepository, IResponseData<User>? response)
    {
        _userRepository = userRepository;
        _response = response;
    }

    /// <summary>
    /// Fetch and return the user data.
    /// </summary>
    /// <param name="request">Input request.</param>
    /// <param name="cancellationToken">Async operation cancel.</param>
    /// <returns>It will fetch and return all the user detail.</returns>
    public async Task<User> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        return _response!.ActionResponse(users!) !;
    }
}
