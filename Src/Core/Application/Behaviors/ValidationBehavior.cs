/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Application.Behaviours;

/// <summary>
/// ValidationBehavior Class used to Validate the Error Message.
/// </summary>
/// <typeparam name="TRequest">Generic Request.</typeparam>
/// <typeparam name="TResponse">Generic Response.</typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">validate input data.</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    /// <summary>
    /// Validate the Request model data with Fluent.
    /// </summary>
    /// <param name="request">Generic Request.</param>
    /// <param name="cancellationToken">cancellationToken.</param>
    /// <param name="next">next task to execute.</param>
    /// <returns>Generic Response.</returns>
    /// <exception cref="ValidationException">Create new validate exception.</exception>
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (this.validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = this.validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

            if (failures.Count != 0)
            {
                throw new FluentValidation.ValidationException(failures);
            }
        }

        return next();
    }
}
