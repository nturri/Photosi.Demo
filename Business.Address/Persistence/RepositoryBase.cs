

using Data.Address.Persistence;

namespace Data.Address.Repositories
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


