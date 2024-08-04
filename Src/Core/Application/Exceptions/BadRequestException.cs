/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a bad request is made.
/// </summary>
public class BadRequestException : ValidationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public BadRequestException(string message)
        : base(message, null, HttpStatusCode.BadRequest)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message, error models, and exception message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="errors">The list of error models associated with the exception.</param>
    /// <param name="exceptionMessage">The exception message.</param>
    public BadRequestException(string message, List<ErrorModel> errors, string exceptionMessage = null!)
       : base(message, errors, HttpStatusCode.BadRequest, exceptionMessage)
    {
    }
}
