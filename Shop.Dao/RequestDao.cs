using System.Linq;
using Shop.Domain;

namespace Shop.Dao
{
    public class RequestDao
    {
        private Context db = new Context();

        public IQueryable<Request> GetAll()
        {
            return db.Requests;
        }

        public bool AddRequest(Request request)
        {
            db.Requests.Add(request);
            db.SaveChanges();
            return true;
        }

        public bool RemoveRequest(int RequestId)
        {

            Request request = db.Requests.Find(RequestId);

            db.Requests.Remove(request);
            db.SaveChanges();

            return true;

        }

        public bool EditRequest(Request request)
        {

            var Request = GetRequest(request.RequestId);

            Request.RequestId = request.RequestId;
            Request.PackedRequest = request.PackedRequest;
            Request.SubmittedRequest = request.SubmittedRequest;
            Request.Products = request.Products;

            db.SaveChanges();


            return true;
        }

        public Request GetRequest(int RequestId)
        {

            var request = db.Requests.Where(a => a.RequestId == RequestId);

            var Request = request.FirstOrDefault();

            return Request;

        }

    }
}

