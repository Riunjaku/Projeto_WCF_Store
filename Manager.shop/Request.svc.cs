using System.Collections.Generic;
using Shop.Domain;
using Shop.Dao;
using Manager.Shopping.Services;
using Manager.Shopping.Model;
using System;

namespace Manager.Shopping
{

    public class Request : ISingleRequest, IMultipleRequest
    {
        private RequestDao dao = new RequestDao();
        private RequestQueueService queue = new RequestQueueService();

        public string RequestRequest(Product product)
        {

            Product x = new Product();
            x.ProductId = product.ProductId;
            x.Quantity = product.Quantity;

            List<Product> ProductsList = new List<Product>();

            ProductsList.Add(x);

            Shop.Domain.Request request = new Shop.Domain.Request();
            request.Products = ProductsList;
            request.PackedRequest = false;
            request.SubmittedRequest = false;
            

            var response = dao.AddRequest(request);

            if (response.ToString() == "True")
            {
                queue.AddRequestToQueue(request.RequestId);
                return "Pedido Realizado com Sucesso";

            }
            else
            {
                return "Algo deu errado.";
            }

        }

        public string RequestRequest(List<Product> Products)
        {
            List<Product> ProductsList = new List<Product>();

            foreach (var item in Products)
            {
                Product product = new Product();
                product.ProductId = item.ProductId;
                product.ProductName = item.ProductName;
                product.Quantity = item.Quantity;

                ProductsList.Add(product);

            }

            Shop.Domain.Request request = new Shop.Domain.Request();
            request.Products = ProductsList;
            request.PackedRequest = false;
            request.SubmittedRequest = false;

            var response = dao.AddRequest(request);

            if (response.ToString() == "True")
            {
                queue.AddRequestToQueue(request.RequestId);
                return "Pedido Realizado com Sucesso";

            }
            else
            {
                return "Algo deu errado.";
            }
        }

        public RequestViewModel NextRequest()
        {
            RequestViewModel request = new RequestViewModel();
            request = queue.GetNextRequest();

            return request;
        }

        public bool PackRequest(int RequestId)
        {
            var request = dao.GetRequest(RequestId);
            request.PackedRequest = true;
            dao.EditRequest(request);

            return true;
        }

        public bool SubmitRequest(int RequestId)
        {
            var request = dao.GetRequest(RequestId);
            request.SubmittedRequest = true;
            dao.EditRequest(request);

            return true;
        }

    }
}