/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Handlers.Users.Commands;

/// <summary>
/// To Update User Details into DB
/// </summary>
/// <param name="User"></param>
public record UpdateUserCommand(User User)
    : IRequest<ResponseMessage>
{
}

/// <summary>
/// User Command Handler for Update Record.
/// </summary>
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseMessage>
{
    private readonly IUserRepository _userRepository;
    private readonly IResponseData<ResponseMessage>? _response;

    public UpdateUserCommandHandler(IUserRepository userRepository, IResponseData<ResponseMessage>? response)
    {
        _userRepository = userRepository;
        _response = response;
    }

    /// <summary>
    /// Update and return the user data.
    /// </summary>
    /// <param name="request">Input request.</param>
    /// <param name="cancellationToken"> operation cancel.</param>
    /// <returns>It will update the given User data.</returns>
    public async Task<ResponseMessage> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.UpdateAsync(request.User);
        return _response!.ActionUpdateResponse(user!) !;
    }
}