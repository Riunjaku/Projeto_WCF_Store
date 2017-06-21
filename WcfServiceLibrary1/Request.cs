using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        public bool PackedRequest { get; set; }

        public bool SubmittedRequest { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }

}