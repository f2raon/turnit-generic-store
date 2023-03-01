using System;

namespace Turnit.GenericStore.Api.Entities;

public class Store
{
    public virtual Guid Id { get; set; }

    public virtual string Name { get; set; }

    public virtual ProductAvailability ProductAvailability { get; set; }
}
