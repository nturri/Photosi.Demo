
using Data.Orders.Persistence;




    namespace Data.Order.Repositories
    {
        public class RepositoryBase<T> 
        {
            protected readonly MySqlDbContext _context;

            public RepositoryBase(MySqlDbContext context)
            {
                _context = context;
            }

       
        }
    }


