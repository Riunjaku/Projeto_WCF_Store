using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Manager.Products.Model
{
    [DataContract]
    public class ProductViewModel
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Price { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }
}