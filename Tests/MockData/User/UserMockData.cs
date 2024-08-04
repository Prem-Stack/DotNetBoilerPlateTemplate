/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.UnitTests.MockData;

/// <summary>
/// Provides mock data and methods for testing the User-related functionality.
/// </summary>
public class UserMockData : BaseUnitTest
{
    private Mock<UserRepository> _userRepositoryMock;
    private readonly IResponseData<User> _userResponse;
    private readonly IResponseData<ResponseMessage> _userResponseUpdate;

    private CreateUserCommandValidator? CreateUserCommandValidator { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserMockData"/> class.
    /// </summary>
    public UserMockData()
    {
        MockDataBaseDbConnection();
        _userRepositoryMock = new Mock<UserRepository>(() => moqConnection!.Object) { CallBase = true };
        _userResponse = new ResponseData<User>();
        _userResponseUpdate = new ResponseData<ResponseMessage>();
        CreateUserCommandValidator = new CreateUserCommandValidator();
    }

    /// <summary>
    /// Retrieves a user by their ID for mocking purposes.
    /// </summary>
    /// <param name="input">The ID of the user to retrieve.</param>
    /// <param name="output">The mocked user object to be returned.</param>
    /// <param name="outputParamResponse">The response value for the output parameter.</param>
    /// <returns>The retrieved user.</returns>
    public async Task<User> GetUserByIdMock(int input, User? output, int outputParamResponse)
    {
        _userRepositoryMock.Setup(x => x.GetOutPutParameterName(It.IsAny<IDataParameterCollection>())).Returns(outputParamResponse);
        MockDataBaseExecuteReader(output);
        _ = GetMediatorMock().Setup(m => m.Send(It.IsAny<GetByIdUserQuery>(), It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(output!));
        var getByIdUserQuery = new GetByIdUserQuery(input);
        GetByIdUsersQueryHandler handler = new(_userRepositoryMock.Object, _userResponse);
        return await handler.Handle(getByIdUserQuery, CancellationToken.None);
    }

    /// <summary>
    /// Creates a mock of the CreateUserCommand method.
    /// </summary>
    /// <param name="output">The output value.</param>
    /// <param name="outputParamResponse">The output parameter response.</param>
    /// <returns>The created user.</returns>
    public async Task<User> CreateUserCommandMock(User? output, int outputParamResponse)
    {
        _userRepositoryMock.Setup(x => x.GetOutPutParameterName(It.IsAny<IDataParameterCollection>())).Returns(outputParamResponse);
        MockDataBaseExecuteReader(output);
        _ = GetMediatorMock().Setup(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(output!));
        var createUserCommand = new CreateUserCommand(output!);
        CreateUserCommandHandler handler = new(_userRepositoryMock.Object, _userResponse);
        return await handler.Handle(createUserCommand, CancellationToken.None);
    }

    /// <summary>
    /// Mocks the UpdateUserCommand method for testing purposes.
    /// </summary>
    /// <param name="output">The output user object.</param>
    /// <param name="outputParamResponse">The output parameter response.</param>
    /// <returns>The update and delete response.</returns>
    public async Task<ResponseMessage> UpdateUserCommandMock(User? output, int outputParamResponse)
    {
        _userRepositoryMock.Setup(x => x.GetOutPutParameterName(It.IsAny<IDataParameterCollection>())).Returns(outputParamResponse);
        MockDataBaseExecuteReader(output);
        _ = GetMediatorMock().Setup(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(output!));
        var updateUserCommand = new UpdateUserCommand(output!);
        UpdateUserCommandHandler handler = new(_userRepositoryMock.Object, _userResponseUpdate);
        return await handler.Handle(updateUserCommand, CancellationToken.None);
    }

    public string CreateUserCommandValidation(User? user)
    {
        var createUserCommand = new CreateUserCommand(user!);
        return CreateUserCommandValidator?.Validate(createUserCommand)?.ToString()!;
    }
}