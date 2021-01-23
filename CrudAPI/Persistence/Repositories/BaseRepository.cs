using CrudAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Persistence.Repositories
{

   // The BaseRepository receives an instance of our AppDbContext through dependency injection
    //and exposes a protected property(a property that can only 
    //be accessible by the children classes) called _context,
      //that gives access to all methods we need to handle database operations.
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
