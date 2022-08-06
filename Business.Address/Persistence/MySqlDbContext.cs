

using Microsoft.EntityFrameworkCore;


namespace Data.Address.Persistence
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        { }


        public DbSet<Data.Address.Entities.Address> Address { get; set; }
     

       
    }
}
