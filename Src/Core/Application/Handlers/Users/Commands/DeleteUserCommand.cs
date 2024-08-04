/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Handlers.Users.Commands;

/// <summary>
/// To Delete User Record into DB
/// </summary>
/// <param name="Id"></param>
public record DeleteUserCommand(long Id)
    : IRequest<ResponseMessage>
{
}

/// <summary>
/// Handles the DeleteUserCommand and performs the necessary operations to delete a user.
/// </summary>
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseMessage>
{
    private readonly IUserRepository _userRepository;
    private readonly IResponseData<ResponseMessage>? _response;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteUserCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="response">The response data.</param>
    public DeleteUserCommandHandler(IUserRepository userRepository, IResponseData<ResponseMessage>? response)
    {
        _userRepository = userRepository;
        _response = response;
    }

    /// <summary>
    /// Deletes a user based on the user id and returns the status.
    /// </summary>
    /// <param name="request">The DeleteUserCommand containing the user ID to be deleted.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The deleted status.</returns>
    public async Task<ResponseMessage> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.DeleteAsync(request.Id);
        return _response!.ActionUpdateResponse(user!) !;
    }
}
