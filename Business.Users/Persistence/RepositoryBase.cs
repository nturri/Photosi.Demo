
using Data.User.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Data.User.Repositories
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


