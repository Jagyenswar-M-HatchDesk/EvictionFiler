﻿

namespace EvictionFiler.Application.DTOs
{
    public class FeesCatalogDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
    }
}