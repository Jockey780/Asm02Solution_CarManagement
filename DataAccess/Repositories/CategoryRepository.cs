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
    }
}
