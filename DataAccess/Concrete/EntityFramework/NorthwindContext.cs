using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //using that connect project class with db tables 
    public class NorthwindContext : DbContext
    {
        //projenin hangi veri tabanı ile ilişkili olduğunu belirten yer
        //this place that which database connect to project
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Northwind;Trusted_Connection=true;");
        }

        //Product classım Products tablosuna bağlansın
        //My Product class connect Products DB table
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers{ get; set; }
    }
}
