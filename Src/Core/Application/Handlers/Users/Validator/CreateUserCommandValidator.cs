/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

using Template.Application.Handlers.Users.Commands;

namespace Template.Application.Handlers.Users.Validator;

/// <summary>
/// Validator for the CreateUserCommand class.
/// </summary>
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserCommandValidator"/> class.
    /// </summary>
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.User.FirstName).NotEmpty().MaximumLength(12).WithMessage(Constant.UserlengthValidation);
        RuleFor(x => x.User.LastName).NotEmpty().MaximumLength(12);
        RuleFor(x => x.User.Gender).NotEmpty();
    }
}
