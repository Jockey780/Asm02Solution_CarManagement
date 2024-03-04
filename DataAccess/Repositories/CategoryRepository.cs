using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategory()=>CategoryDAO.Instance.GetAllCategory();
        public List<int> GetCatagories()=>CategoryDAO.Instance.GetCatagories();
        public Category GetCategoryById(int id)=>CategoryDAO.Instance.GetCategoryById(id);
        public Category CreateCategory(Category category)=>CategoryDAO.Instance.CreateCategory(category);
        public Category UpdateCategory(Category category)=>CategoryDAO.Instance.UpdateCategory(category);
        public void DeleteCategory(int categoryId) => CategoryDAO.Instance.DeleteCategory(categoryId);
    }
}
