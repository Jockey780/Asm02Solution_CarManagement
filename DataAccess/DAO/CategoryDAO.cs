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
    }
}
