/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Domain.Common;

/// <summary>
/// The AppSettingsModel class map for all app setting values.
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Gets or sets the SQL connection string.
    /// </summary>
    public string SQLConnection { get; set; } = string.Empty;
}
