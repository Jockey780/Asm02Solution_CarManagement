﻿using BusinessObjects.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }

        public Category CreateCategory(Category category)
        {
            return categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int id) => categoryRepository.DeleteCategory(id);

        public List<Category> GetAllCategory()
        {
            return categoryRepository.GetAllCategory();
        }

        public List<int> GetCatagories()
        {
            return categoryRepository.GetCatagories();
        }

        public Category GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public Category UpdateCategory(Category category)
        {
            return categoryRepository.UpdateCategory(category);
        }
    }
}
