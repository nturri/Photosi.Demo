
using Data.Products.Persistence;




    namespace Data.Products.Repositories
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


