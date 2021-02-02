using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Models
{
    public class Land: Property
    {
      
        public int Area { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price =>  (Area * 3000);
        public Boolean CanBeFarmed { get; set; }
    }
}