/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when there is no content available.
/// </summary>
public class NoContentException : ValidationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoContentException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public NoContentException(string message)
       : base(message, null, HttpStatusCode.NoContent)
    {
    }
}