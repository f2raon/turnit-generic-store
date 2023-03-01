using FluentNHibernate.Mapping;

namespace Turnit.GenericStore.Api.Entities.Configurations;

public class CategoryMap : ClassMap<Category>
{
    public CategoryMap()
    {
        Schema("public");
        Table("category");

        Id(x => x.Id, "id");
        Map(x => x.Name, "name");
        HasMany(e => e.ProductCategories).Table("product_category");
    }
}
