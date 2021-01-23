using CrudAPI.Domain.Repositories;
using CrudAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Persistence.Repositories
{
    //implement the IUnitOfWork interface
    public class UnitOfWork : IUnitOfWork
    {
        //only save all changes into the database after 
       //it finish modifying  data, using  repositories.
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
