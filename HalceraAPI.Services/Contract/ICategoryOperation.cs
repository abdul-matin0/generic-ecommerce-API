﻿using HalceraAPI.Model;

namespace HalceraAPI.Services.Contract
{
    /// <summary>
    /// Category Operations
    /// </summary>
    public interface ICategoryOperation
    {
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of categories</returns>
        Task<IEnumerable<Category>?> GetAllCategories();
        /// <summary>
        /// Get category by Id
        /// </summary>
        /// <param name="categoryId">id of category to retrieve</param>
        /// <returns>Category details from DB</returns>
        Task<Category?> GetCategory(int categoryId);
        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="category">Category details to be created</param>
        /// <returns>Created category</returns>
        Task<Category> CreateCategory(Category category);
        /// <summary>
        /// Update details of a category
        /// </summary>
        /// <param name="category">Category data to be updated</param>
        /// <returns>updated category details</returns>
        Task<Category> UpdateCategory(Category category);
        /// <summary>
        /// Delete category record
        /// </summary>
        /// <param name="categoryId">id of category to be deleted</param>
        /// <returns>boolean indicating if delete operation is success</returns>
        Task<bool> DeleteCategory(int categoryId);
    }
}
