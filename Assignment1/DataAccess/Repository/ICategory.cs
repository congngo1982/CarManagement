using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface ICategory
    {
        public Category GetCategory(int id);
        public List<Category> GetCategories();
    }
}
