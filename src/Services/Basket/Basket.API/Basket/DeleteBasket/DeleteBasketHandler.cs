namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string userName) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.userName).NotEmpty().WithMessage("UserName is Required");
    }
}

internal class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(command.userName, cancellationToken);

        return new DeleteBasketResult(true);
    }
}
