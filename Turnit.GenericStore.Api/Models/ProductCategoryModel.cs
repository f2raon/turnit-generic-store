using System;

namespace Turnit.GenericStore.Api.Models;

public class ProductCategoryModel
{
    public Guid? CategoryId { get; set; }

    public ProductModel[] Products { get; set; }
}
