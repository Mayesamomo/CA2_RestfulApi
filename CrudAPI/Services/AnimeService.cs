using CrudAPI.Domain.Models;
using CrudAPI.Domain.Models.Queries;
using CrudAPI.Domain.Repositories;
using CrudAPI.Domain.Serrvices;
using CrudAPI.Domain.Serrvices.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AnimeService(IAnimeRepository animeRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _animeRepository = animeRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<AnimeResponse> DeleteAsync(int id)
        {
            var existingAnime = await _animeRepository.FindByIdAsync(id);

            if (existingAnime == null)
                return new AnimeResponse("Anime not found.");

            try
            {
                _animeRepository.Remove(existingAnime);
                await _unitOfWork.CompleteAsync();

                return new AnimeResponse(existingAnime);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new AnimeResponse($"An error occurred when deleting the Anime: {ex.Message}");
            }
        }

        public async Task<QueryResult<Anime>> ListAsync(AnimesQuery query)
        {
        
                return await _animeRepository.ListAsync(query);
        }

        public Task<IEnumerable<Anime>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AnimeResponse> SaveAsync(Anime anime)
        {
            try
            {
                //Check if the category ID is valid before adding the anime, to avoid errors.
                var existingCategory = await _categoryRepository.FindByIdAsync(anime.CategoryId);
                if (existingCategory == null)
                    return new AnimeResponse("Invalid category.");
                await _animeRepository.AddAsync(anime);
                await _unitOfWork.CompleteAsync();

                return new AnimeResponse(anime);
            }
            catch (Exception ex)
            {
                // return error before injecting data into the database
                return new AnimeResponse($"Sorry!. An error occurred when saving the category: {ex.Message}"); //using string literal to concatenate
            }
            //try
            //{ 
            //     //Check if the category ID is valid before adding the anime, to avoid errors.
            //    var existingCategory = await _categoryRepository.FindByIdAsync(anime.CategoryId);
            //    if (existingCategory == null)
            //        return new AnimeResponse("Invalid category.");

            //    await _animeRepository.AddAsync(anime);
            //    await _unitOfWork.CompleteAsync();

            //    return new AnimeResponse(anime);
            //}
            //catch (Exception ex)
            //{

            //    return new AnimeResponse($"An error occurred when saving the Anime: {ex.Message}");
            //}
        }

        public async Task<AnimeResponse> UpdateAsync(int id, Anime anime)
        {
            var existingAnime = await _animeRepository.FindByIdAsync(id);

            if (existingAnime == null)
                return new AnimeResponse("Anime not found.");

            var existingCategory = await _categoryRepository.FindByIdAsync(anime.CategoryId);
            if (existingCategory == null)
                return new AnimeResponse("Invalid category.");

            existingAnime.Name = anime.Name;
            existingAnime.Description = anime.Description;
            existingAnime.Producer = anime.Producer;
            existingAnime.ReleaseDate = anime.ReleaseDate;
            existingAnime.Istreaming = anime.Istreaming;
            existingAnime.Thumbnail = anime.Thumbnail;
            existingAnime.CategoryId = anime.CategoryId;
            

            try
            {
                _animeRepository.Update(existingAnime);
                await _unitOfWork.CompleteAsync();

                return new AnimeResponse(existingAnime);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new AnimeResponse($"An error occurred when updating the anime: {ex.Message}");
            }
        }
    }
}
