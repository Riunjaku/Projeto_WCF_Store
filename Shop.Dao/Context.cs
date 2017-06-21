using System.Data.Entity;
using Shop.Domain;

namespace Shop.Dao
{
    public class Context : DbContext
    {
            public Context() : base("DefaultConnection")
            {
                Database.SetInitializer<Context>(
                    new CreateDatabaseIfNotExists<Context>());

                Database.Initialize(false);

            }

            public DbSet<Product> Products { get; set; }
            public DbSet<Request> Requests { get; set; }


        
    }
}
