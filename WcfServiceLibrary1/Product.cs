using System.ComponentModel.DataAnnotations;

namespace Shop.Domain
{
    public class Product 
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }

        public string Flag { get; set; }

        public virtual Request request { get; set; }
    }
}
