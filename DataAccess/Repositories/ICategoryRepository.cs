using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategory();
        public List<int> GetCatagories();
        public Category GetCategoryById(int id);
    }
}
