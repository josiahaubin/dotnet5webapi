using System;

namespace Catalog.Entities
{
    //NOTE use record types for immutable objects, with-expressions, value-based equality support
    public record Item
    {
        public Guid ID { get; init; } //NOTE init only properties
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}