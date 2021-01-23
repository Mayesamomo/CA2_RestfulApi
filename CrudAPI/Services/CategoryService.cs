using CrudAPI.Domain.Models;
using CrudAPI.Domain.Repositories;
using CrudAPI.Domain.Serrvices;
using CrudAPI.Domain.Serrvices.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
		{
			_categoryRepository = categoryRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Category>> ListAsync()
		{
			return await _categoryRepository.ListAsync();
		}

		public async Task<CategoryResponse> SaveAsync(Category category)
		{
			//this method tries add the new category to the database first
			//and then the api method(saveCategoryResponse) try to save it,
			//wrapping everything inside a try-catch block to handle errors and exceptions
			try
			{
				await _categoryRepository.AddAsync(category);
				await _unitOfWork.CompleteAsync();

				return new CategoryResponse(category);
			}
			catch (Exception ex)
			{
				// return error before injecting data into the database
				return new CategoryResponse($"Sorry!. An error occurred when saving the category: {ex.Message}"); //using string literal to concatenate
			}
		}

		public async Task<CategoryResponse> UpdateAsync(int id, Category category)
		{
			var existingCategory = await _categoryRepository.FindByIdAsync(id);

			if (existingCategory == null)
				return new CategoryResponse("Category not found.");

			existingCategory.Name = category.Name;

			try
			{
				_categoryRepository.Update(existingCategory);
				await _unitOfWork.CompleteAsync();

				return new CategoryResponse(existingCategory);
			}
			catch (Exception ex)
			{
				
				return new CategoryResponse($"Sorry!. An error occurred when updating the category: {ex.Message}");
			}
		}

		public async Task<CategoryResponse> DeleteAsync(int id)
		{
			var existingCategory = await _categoryRepository.FindByIdAsync(id);

			if (existingCategory == null)
				return new CategoryResponse("Category not found.");

			try
			{
				_categoryRepository.Remove(existingCategory);
				await _unitOfWork.CompleteAsync();

				return new CategoryResponse(existingCategory);
			}
			catch (Exception ex)
			{
				
				return new CategoryResponse($"Sorry!.An error occurred when deleting the category: {ex.Message}");
			}
		}
	}
}
