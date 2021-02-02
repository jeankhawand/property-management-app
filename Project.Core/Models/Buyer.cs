using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Credits { get; set; }
        
        public ICollection<Property> Properties { get; set; }
    }
}