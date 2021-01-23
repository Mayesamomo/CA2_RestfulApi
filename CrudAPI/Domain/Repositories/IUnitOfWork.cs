using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Repositories
{
    //since it is not a safe approach to save data in the repository
    //due to data incosistency and it should only go into the database only after 
    //all the complexity has been simplified and finished
    public interface IUnitOfWork
    {
        // exposes a method that will asynchronously complete data management operations.
        Task CompleteAsync();
    }
}
