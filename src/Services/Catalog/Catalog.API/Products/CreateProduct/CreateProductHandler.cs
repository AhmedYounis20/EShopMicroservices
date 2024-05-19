using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name,List<string> Category,string Descritpion,string ImagePath, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
public class CreateProductHandler : ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // create Product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            ImageFile = command.ImagePath,
            Description = command.Descritpion,
            Price = command.Price,
        };
        
        // save to database ToDo
        await Task.CompletedTask;

        // return CreateProductResult result
        return new CreateProductResult(Guid.NewGuid());

    }
}
