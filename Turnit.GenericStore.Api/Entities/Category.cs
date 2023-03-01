using System;
using System.Collections.Generic;

namespace Turnit.GenericStore.Api.Entities;

public class Category
{
    public virtual Guid Id { get; set; }

    public virtual string Name { get; set; }

    public virtual IList<ProductCategory> ProductCategories { get; set; }
}
