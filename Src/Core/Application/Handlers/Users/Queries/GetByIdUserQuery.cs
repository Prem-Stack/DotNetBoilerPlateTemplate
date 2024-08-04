/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Handlers.Users.Queries;

/// <summary>
/// To fetch the spectfic User details
/// </summary>
/// <param name="Id"></param>
public record GetByIdUserQuery(long Id)
    : IRequest<User>
{
}

/// <summary>
/// User get by Id Handler.
/// </summary>
public class GetByIdUsersQueryHandler : IRequestHandler<GetByIdUserQuery, User>
{
    private readonly IUserRepository _userRepository;
    private readonly IResponseData<User>? _response;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetByIdUsersQueryHandler"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="response">The response data.</param>
    public GetByIdUsersQueryHandler(IUserRepository userRepository, IResponseData<User>? response)
    {
        _userRepository = userRepository;
        _response = response;
    }

    /// <summary>
    /// Fetch and return the user data.
    /// </summary>
    /// <param name="request">Input request.</param>
    /// <param name="cancellationToken">Async operation calcel.</param>
    /// <returns>It will fetch and return the given user details.</returns>
    public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        return _response!.ActionResponse(user!) !;
    }
}
