using FluentNHibernate.Mapping;
using System;

namespace Turnit.GenericStore.Api.Entities.Configurations;

public class ProductMap : ClassMap<Product>
{
    public ProductMap()
    {
        Schema("public");
        Table("product");

        Id(x => x.Id, "id");
        Map(x => x.Name, "name");
        Map(x => x.Description, "description");
        HasMany(e => e.ProductCategories).Table("product_category");
        HasMany(e => e.ProductAvailablities).Table("product_availability");
    }
}
