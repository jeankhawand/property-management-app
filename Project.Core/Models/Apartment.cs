using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Models
{
    public class Apartment:Property
    {
        public int NbOfRooms { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price =>  (NbOfRooms * 15000);
    }
}