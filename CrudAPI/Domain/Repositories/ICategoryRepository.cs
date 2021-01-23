using CrudAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Repositories
{
   public interface ICategoryRepository
    {
        //To update the category ,
       //return the current data from the database,
      //if it exists, thento update it.
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task<Category> FindByIdAsync(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}
