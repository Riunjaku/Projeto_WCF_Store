using Manager.Products.Model;
using Manager.Products.Services;
using Newtonsoft.Json;
using Shop.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Manager.Products
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Produto : IProduct
    {
        ProductDao dao = new ProductDao();
        ProductQueueService queue = new ProductQueueService();

        public bool AddToQueue(ProductViewModel product)
        {
            queue.AddToQueue(product);

            return true;
        }

        public bool ConsumeQueue()
        {
            queue.ConsumeQueue();

            return true;

        }

        public string GetAllProducts()
        {

            var x = dao.GetAll();

            List<Shop.Domain.Product> products = new List<Shop.Domain.Product>();

            foreach (var item in x)
            {

                products.Add(item);

            }

            var Products = JsonConvert.SerializeObject(products);

            return Products;
        }


        public bool CreateProduct(Shop.Domain.Product product)
        {

            dao.AddProduct(product);
            return true;

        }

        public bool EditProduct(Shop.Domain.Product product)
        {

            dao.EditProduct(product);
            return true;

        }

        public bool RemoveProduct(int ProductId)
        {

            dao.RemoveProduct(ProductId);
            return true;
        }









    }




}
