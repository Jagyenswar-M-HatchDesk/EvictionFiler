

namespace EvictionFiler.Application.DTOs
{
    public class FeesCatalogDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public Guid? LabelId { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }

        public string Category { get; set; }
    }
}