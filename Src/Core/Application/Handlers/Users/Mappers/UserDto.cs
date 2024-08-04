/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Handlers.Users.Mappers;

/// <summary>
/// Represents a data transfer object for a user.
/// </summary>
public class UserDto : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    public virtual string? Name { get; set; }

    /// <summary>
    /// Gets or sets the gender of the user.
    /// </summary>
    public string? Gender { get; set; }
}
