using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private readonly CarManagementContext dbContext = null;

        private CategoryDAO()
        {
            dbContext = new CarManagementContext();
        }
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }

        public Category GetCategoryByName(string categoryName)
        {
            Category category = null;
            try
            {
                var dbContext = new CarManagementContext();
                category = dbContext.Categories.SingleOrDefault(m => m.CategoryName.Equals(categoryName));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                using (var dbContext = new CarManagementContext())
                {
                    return dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Category> GetAllCategory() 
        {
            List<Category> list = null;
            try
            {
                var dbContext = new CarManagementContext();
                list = dbContext.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        // loai category co ten la gi
        public List<int> GetCatagories()
        {
            List<int> catagories;
            try
            {
                var dbContext = new CarManagementContext();
                catagories = dbContext.Categories
                .Where(car => car.CategoryId != null)
                .Select(car => car.CategoryId)
                .Distinct()
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return catagories;
        }

        public Category CreateCategory(Category category)
        {
            Category _category = GetCategoryByName(category.CategoryName);
            try
            {
                if (_category == null)
                {
                    var dbContext = new CarManagementContext();
                    dbContext.Categories.Add(category);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer is existed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }
    }
}
