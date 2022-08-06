

using Microsoft.EntityFrameworkCore;


namespace Data.User.Persistence
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {

        }


        public DbSet<Data.Users.Entities.User> Users { get; set; }



    }
}
