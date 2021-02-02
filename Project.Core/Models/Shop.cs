using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Models
{
    public class Shop : Property
    {

        public int Area { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price =>  ((Area * 3000)>50 ? 120000 : 80000);
        public Business Business { get; set; }
    }
}