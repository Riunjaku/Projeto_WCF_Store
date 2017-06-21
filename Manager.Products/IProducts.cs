using Manager.Products.Model;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Manager.Products
{
    [ServiceContract(Name = "Products", Namespace = ("http://localhost:42313/Products"))]
    public interface IProduct
    {
        [OperationContract]
        bool AddToQueue(ProductViewModel product);

        [OperationContract]
        bool ConsumeQueue();

        [OperationContract]
        string GetAllProducts();

        [OperationContract]
        bool CreateProduct(Product product);

        [OperationContract]
        bool EditProduct(Product product);

        [OperationContract]
        bool RemoveProduct(int ProductId);




    }
}
