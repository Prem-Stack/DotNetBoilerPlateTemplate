/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure.Common;

/// <summary>
/// Provides a collection of common enumeration types.
/// </summary>
public static class CommonEnum
{
    /// <summary>
    /// Represents the possible exception codes.
    /// </summary>
    public enum ExceptionCode
    {
        Success = 1,
        DBValidationError = -1,
        DBException = -2,
        NoContent = -3
    }
}
