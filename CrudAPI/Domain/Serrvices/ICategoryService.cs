using CrudAPI.Domain.Models;
using CrudAPI.Domain.Serrvices.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Serrvices
{
   public interface ICategoryService
    {
        //The implementations of the ListAsync method must asynchronously 
        //return an enumeration of categories.
        //"Task" class returns an encapsulated async
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);


    }
}
