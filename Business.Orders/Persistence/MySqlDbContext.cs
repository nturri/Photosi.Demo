

using Microsoft.EntityFrameworkCore;


namespace Data.Orders.Persistence
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        { }


        public DbSet<Data.Orders.Entities.Order> Orders { get; set; }

        public DbSet<Data.Orders.Entities.OrderDetail> OrdersDetails { get; set; }


    }
}
