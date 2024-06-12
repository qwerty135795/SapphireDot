using FluentValidation;
using MediatR;

namespace MessageService.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();
        
        
        var context = new ValidationContext<TRequest>(request);

        var failures = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var errors = failures.Where(r => !r.IsValid)
            .SelectMany(result => result.Errors)
            .ToList();

        if (errors.Count != 0)
        {
            throw new ValidationException("ValidationError", errors);
        }

        return await next();
    }
}