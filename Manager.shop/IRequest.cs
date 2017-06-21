using System.Collections.Generic;
using System.ServiceModel;
using Shop.Domain;
using Manager.Shopping.Model;

namespace Manager.Shopping
{

    [ServiceContract(Name = "SingleRequest", Namespace = ("http://localhost:42312/SingleRequest"))]
    public interface ISingleRequest
    {
        [OperationContract]
        string RequestRequest(Product Product);

        [OperationContract]
        RequestViewModel NextRequest();

        [OperationContract]
        bool PackRequest(int RequestId);

        [OperationContract]
        bool SubmitRequest(int RequestId);

    }

    [ServiceContract(Name = "MultipleRequest", Namespace = ("http://localhost:42312/MultipleRequest"))]
    public interface IMultipleRequest
    {
        [OperationContract]
        string RequestRequest(List<Product> ProductList);

        [OperationContract]
        RequestViewModel NextRequest();

        [OperationContract]
        bool PackRequest(int RequestId);

        [OperationContract]
        bool SubmitRequest(int RequestId);
    }
}