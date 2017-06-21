using Manager.Products.Model;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using Shop.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manager.Products.Services
{
    public class ProductQueueService
    {
        private ProductDao dao = new ProductDao();
        private Shop.Domain.Product produto2 = new Shop.Domain.Product();
        
        public bool AddToQueue(ProductViewModel product)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("RequestQueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();



            var Json = JsonConvert.SerializeObject(product);


            CloudQueueMessage message = new CloudQueueMessage(Json);
            queue.AddMessage(message);

            return true;
        }

        public bool ConsumeQueue()
        {

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("RequestQueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            var mensagem = queue.GetMessage().AsString;

            var Json = JsonConvert.DeserializeObject<ProductViewModel>(mensagem);

            switch (Json.Flag)
            {
                case "Add":
                    Shop.Domain.Product product = new Shop.Domain.Product();
                    product.ProductId = Json.ProductId;
                    product.Category = Json.Category;
                    product.Image = Json.Image;
                    product.ProductName = Json.ProductName;
                    product.Price = Json.Price;
                    product.Quantity = Json.Quantity;
                    dao.AddProduct(product);
                    break;

                case "Remove":
                    dao.RemoveProduct(Json.ProductId);
                    break;

                case "Edit":
                    Shop.Domain.Product productEdit = new Shop.Domain.Product();
                    productEdit.ProductId = Json.ProductId;
                    productEdit.Category = Json.Category;
                    productEdit.Image = Json.Image;
                    productEdit.ProductName = Json.ProductName;
                    productEdit.Price = Json.Price;
                    productEdit.Quantity = Json.Quantity;
                    dao.EditProduct(productEdit);
                    break;


                default:
                    return false;

            }

            return true;
        }
    }
}
