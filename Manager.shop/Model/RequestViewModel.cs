using Shop.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Manager.Shopping.Model
{
    [DataContract]
    public class RequestViewModel
    {
        [Key]
        [DataMember]
        public int RequestId { get; set; }
        [DataMember]
        public bool PackedRequest { get; set; }
        [DataMember]
        public bool SubmittedRequest { get; set; }
        [DataMember]
        public virtual ICollection<Product> Products { get; set; }
    }
}