/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Exceptions;

/// <summary>
/// To perform sql exceptions.
/// </summary>
public class SQLException : ValidationException
{
    /// <summary>
    /// SQLException with error message.
    /// </summary>
    /// <param name="message">Error message.</param>
    public SQLException(string message)
        : base(message, null, HttpStatusCode.BadRequest)
    {
    }

    /// <summary>
    /// SQLException with exception message.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <param name="errors">Error list.</param>
    /// <param name="exceptionMessage">exception message.</param>
    public SQLException(string message, List<ErrorModel>? errors, string exceptionMessage = null!)
       : base(message, errors, HttpStatusCode.InternalServerError, exceptionMessage)
    {
    }
}
