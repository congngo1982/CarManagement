using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        private ICategory cate;
        public CategoryDAO() {
            cate = new CategoryRepository();
        }

        public List<Category> GetAll()
        {
            return cate.GetCategories();
        }
    }
}
