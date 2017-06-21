using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using Shop.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manager.shop.Services
{
    public class QueueService
    {
        private ProductDao dao = new ProductDao();
        private RequestDao dao2 = new RequestDao();

        public bool AddRequestToQueue(int RequestId)
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

            var request = dao2.GetRequest(RequestId);


            var Json = JsonConvert.SerializeObject(request);


            CloudQueueMessage message = new CloudQueueMessage(Json);
            queue.AddMessage(message);


            return true;
        }

        public String GetNextRequest()
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


            CloudQueueMessage peekedMessage = queue.PeekMessage();

            queue.DeleteMessage(peekedMessage);



            return peekedMessage.AsString;
        }


    }
}