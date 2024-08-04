/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.UnitTests.Controllers;

/// <summary>
/// Represents a base class for controller tests.
/// </summary>
public class BaseControllerTest
{
    /// <summary>
    /// Create mock for application app setting model.
    /// </summary>
    /// <returns>It will return App Settings Data.</returns>
    public static IOptionsMonitor<AppSettings> AppSettingsModel()
    {
        var optionsMonitorMock = new Mock<IOptionsMonitor<AppSettings>>();
        optionsMonitorMock.Setup(o => o.CurrentValue).Returns(new AppSettings { SQLConnection = ConstantTest.TestData });
        return optionsMonitorMock.Object;
    }
}