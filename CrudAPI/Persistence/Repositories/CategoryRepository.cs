using CrudAPI.Domain.Models;
using CrudAPI.Domain.Repositories;
using CrudAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Persistence.Repositories
{
    //inheritting the baseRepo and implementing the ICategoryRepo
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        //adding a new category to the set
        // this method calls saveChanges method from the context class 
        //to execute this queries into the DB

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
