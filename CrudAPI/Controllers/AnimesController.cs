using AutoMapper;
using CrudAPI.Domain.Models;
using CrudAPI.Domain.Models.Queries;
using CrudAPI.Domain.Serrvices;
using CrudAPI.Extensions;
using CrudAPI.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimeService _animeService;
        private readonly IMapper _mapper;
        public AnimesController(IAnimeService animeService, IMapper mapper)
        {
            _animeService = animeService;
            _mapper = mapper;
        }

        //Gets anime Lists
        [HttpGet]
        public async Task<QueryResultResource<AnimeResource>> ListAsync([FromQuery] AnimesQueryResource query)
        {
            var animesQuery = _mapper.Map<AnimesQueryResource, AnimesQuery>(query);
            var queryResult = await _animeService.ListAsync(animesQuery);

            var resource = _mapper.Map<QueryResult<Anime>, QueryResultResource<AnimeResource>>(queryResult);
            return resource;
        }


        //Add anime to the database POST
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAnimeResource resource)
        {
            var anime = _mapper.Map<SaveAnimeResource, Anime>(resource);
            var result = await _animeService.SaveAsync(anime);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var animeResource = _mapper.Map<Anime, AnimeResource>(result.Anime);
            return Ok(animeResource);
        }


        //delete an anime with a certain Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _animeService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Anime, AnimeResource>(result.Anime);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
       
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAnimeResource animeresource)
        {
            var anime = _mapper.Map<SaveAnimeResource, Anime>(animeresource);
            var result = await _animeService.UpdateAsync(id, anime);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var animeResource = _mapper.Map<Anime, AnimeResource>(result.Anime);
            return Ok(animeResource);
        }
    }
}
