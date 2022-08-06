

using Microsoft.EntityFrameworkCore;


namespace Data.Products.Persistence
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        { }


        public DbSet<Data.Products .Entities.Product> Products { get; set; }
     

       
    }
}
