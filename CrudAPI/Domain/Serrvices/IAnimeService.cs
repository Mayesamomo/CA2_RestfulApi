using CrudAPI.Domain.Models;
using CrudAPI.Domain.Models.Queries;
using CrudAPI.Domain.Serrvices.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Domain.Serrvices
{
  public interface IAnimeService
    {
    
        Task<QueryResult<Anime>> ListAsync(AnimesQuery query);
        Task<AnimeResponse> SaveAsync(Anime anime);
        Task<AnimeResponse> UpdateAsync(int id, Anime anime);
        Task<AnimeResponse> DeleteAsync(int id);
    }
}
    

