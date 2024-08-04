/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.UnitTests.Controllers;

/// <summary>
/// User Controller a test class for the UserController.
/// </summary>
public class UserControllerTest : BaseControllerTest
{
    private readonly UserMockData _userMockData;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserControllerTest"/> class.
    /// </summary>
    public UserControllerTest()
    {
        _userMockData = new UserMockData();
    }

    /// <summary>
    /// Get User By Id a test method for getting a user by ID.
    /// </summary>
    /// <param name="input">The input parameter.</param>
    /// <param name="output">The expected output.</param>
    /// <param name="outputParamResponse">The expected output parameter response.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Theory]
    [JsonFileData("User.json", "GetByIdPositive", true)]
    public async Task Get_User_By_Id_Test(int input, User? output, int outputParamResponse)
    {
        var result = await _userMockData.GetUserByIdMock(input, output, outputParamResponse);
        Assert.Equal(result!.FirstName, output?.FirstName);
    }

    /// <summary>
    /// Create User Test a test method for creating a user.
    /// </summary>
    /// <param name="output">The expected output.</param>
    /// <param name="outputParamResponse">The expected output parameter response.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Theory]
    [JsonFileData("User.json", "CreateUserPositive", true)]
    public async Task Create_User_Test(User? output, int outputParamResponse)
    {
        var result = await _userMockData.CreateUserCommandMock(output, outputParamResponse);
        Assert.Equal(result!.FirstName, output?.FirstName);
    }

    /// <summary>
    /// Update User Test a test method for updating a user.
    /// </summary>
    /// <param name="output">The expected output.</param>
    /// <param name="outputParamResponse">The expected output parameter response.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Theory]
    [JsonFileData("User.json", "CreateUserPositive", true)]
    public async Task Update_User_Test(User? output, int outputParamResponse)
    {
        var result = await _userMockData.UpdateUserCommandMock(output, outputParamResponse);
        Assert.Equal(Constant.UpdateSuccessMessage, result.Message);
    }

    /// <summary>
    /// Test method for validating the CreateUserCommandValidation method in the UserController class.
    /// </summary>
    /// <param name="output">The user object to be validated.</param>
    /// <param name="expectedResult">The expected validation result.</param>
    [Theory]
    [JsonFileData("User.json", "CreateUserFluentValidation", true)]
    public void Create_User_Fluent_Validation_Test(User? output, string expectedResult)
    {
        string result = _userMockData.CreateUserCommandValidation(output);
        Assert.Equal(expectedResult, result);
    }
}
