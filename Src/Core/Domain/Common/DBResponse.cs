/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Domain.Common;

/// <summary>
/// The DBResponse class for all database resdponse.
/// </summary>
public class DBResponse
{
    /// <summary>
    /// Gets or sets the ID.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    /// Gets or sets the errors associated with the database response.
    /// </summary>
    public string? Errors { get; set; }

    /// <summary>
    /// Gets or sets the data associated with the database response.
    /// </summary>
    public string? Data { get; set; }
}
