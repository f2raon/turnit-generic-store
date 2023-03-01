using System;
using System.Collections.Generic;

namespace Turnit.GenericStore.Api.Entities;

public class Product
{
    public virtual Guid Id { get; set; }

    public virtual string Name { get; set; }

    public virtual string Description { get; set; }

    public virtual IList<ProductCategory> ProductCategories { get; set; }

    public virtual IList<ProductAvailability> ProductAvailablities { get; set; }
}
