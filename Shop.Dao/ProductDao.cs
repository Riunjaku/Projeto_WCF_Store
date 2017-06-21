using System.Linq;
using Shop.Domain;

namespace Shop.Dao
{
    public class ProductDao
    {
        private Context db = new Context();

        public IQueryable<Product> GetAll()
        {

            return db.Products.Where(x => x.request == null);
        }

        public Product GetProduct(int ProductId)
        {

            var Product = db.Products.Where(a => a.ProductId == ProductId);

            var GetProduct = Product.FirstOrDefault<Product>();

            return GetProduct;

        }

        public bool AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return true;
        }

        public bool RemoveProduct(int ProductId)
        {

            Product product = db.Products.Find(ProductId);

            db.Products.Remove(product);
            db.SaveChanges();

            return true;

        }

        public bool EditProduct(Product product)
        {

            var Product = GetProduct(product.ProductId);

            Product.ProductId = product.ProductId;
            Product.ProductName = product.ProductName;
            Product.Category = product.Category;
            Product.Quantity = product.Quantity;
            Product.Price = product.Price;
            Product.Image = product.Image;

            db.SaveChanges();


            return true;
        }

        public bool SellProducts(int ProductId, int Quantity)
        {

            Product product = db.Products.Find(ProductId);


            if (product.Quantity == 0)
            {
                return false;

            }
            else if (Quantity <= 0)
            {
                return false;

            }
            else
            {
                product.Quantity = product.Quantity - Quantity;

                db.SaveChanges();
                return true;

            }

        }
    }
}

