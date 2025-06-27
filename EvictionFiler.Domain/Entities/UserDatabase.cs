using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class UserDatabase : Base
    {
        [Key]
        public Guid Id { get; set; }

        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty ;
    }
}
