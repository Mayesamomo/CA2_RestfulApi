using CrudAPI.Domain.Models;
using CrudAPI.Domain.Models.Queries;
using CrudAPI.Domain.Repositories;
using CrudAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Persistence.Repositories
{
    public class AnimeRepository : BaseRepository, IAnimeRepository
    {
        public AnimeRepository(AppDbContext context) : base(context)
        {
        }


		public async Task<QueryResult<Anime>> ListAsync(AnimesQuery query)
		{
			IQueryable<Anime> queryable = _context.Animes
													.Include(a => a.Category)
													.AsNoTracking();

			// AsNoTracking tells EF Core it doesn't need to track changes on listed entities.
			
			if (query.CategoryId.HasValue && query.CategoryId > 0)
			{
				queryable = queryable.Where(p => p.CategoryId == query.CategoryId);
			}

			//  Counts all items present in the database for the given query, to return as part of the pagination data.
			int totalItems = await queryable.CountAsync();

			// Returns only the amount of desired items. 
			List<Anime> animes = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
													.Take(query.ItemsPerPage)
													.ToListAsync();

			// Return a query result, containing all items and the amount of items in the database.
			return new QueryResult<Anime>
			{
				Items = animes,
				TotalItems = totalItems,
			};
		}


		//can't use FindAsync because "Include" changes the method's return type
		public async Task<Anime> FindByIdAsync(int id)
		{
			return await _context.Animes
								 .Include(p => p.Category)
								 .FirstOrDefaultAsync(p => p.Id == id); 
		}

		public async Task AddAsync(Anime anime)
		{
			await _context.Animes.AddAsync(anime);
		}

		public void Update(Anime anime)
		{
			_context.Animes.Update(anime);
		}

		public void Remove(Anime anime)
		{
			_context.Animes.Remove(anime);
		}

        
    }
}
