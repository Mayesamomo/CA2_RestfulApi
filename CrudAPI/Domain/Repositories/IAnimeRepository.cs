using CrudAPI.Domain.Models;
using CrudAPI.Domain.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Repositories
{
  public  interface IAnimeRepository
    {
        Task<QueryResult<Anime>> ListAsync(AnimesQuery query);
        Task AddAsync(Anime anime);
        Task<Anime> FindByIdAsync(int id);
        void Update(Anime anime);
        void Remove(Anime Anime);
    }
}
