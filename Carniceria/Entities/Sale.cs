using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Carniceria.Entities
{
    public class SaleForview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int idProduct { get; set; }
        public decimal total { get; set; }
        public string date { get; set; }

        public decimal amount { get; set; }

        public Product Product { get; set; }

    }
}
