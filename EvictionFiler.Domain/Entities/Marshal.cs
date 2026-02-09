using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Domain.Entities
{
    public class Marshal : DeletableGuidEntity
    {
        [Key]
        public Guid Id { get; set; }

        //public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string DocketNo {  get; set; } = string.Empty;

        public string BadgeNumber { get; set; }

        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;

        public string OfficeAddress { get; set; } = string.Empty;
    }
}
