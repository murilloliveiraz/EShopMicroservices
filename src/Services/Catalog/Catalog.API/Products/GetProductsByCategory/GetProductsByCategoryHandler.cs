﻿namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string category) : IQuery<GetProductsByCategoryResult>;
public record GetProductsByCategoryResult(IEnumerable<Product> Product);
internal class GetProductsByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        var product = await session.Query<Product>().Where(p => p.Category.Contains(query.category)).ToListAsync(cancellationToken);

        return new GetProductsByCategoryResult(product);
    }
}
