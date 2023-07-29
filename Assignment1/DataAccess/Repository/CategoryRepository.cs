using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategory
    {
        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }
        public List<Category> GetCategories()
        {
            var context = new NgoncAssignment1Context();
            IEnumerable<Category> categories = context.Categories;
            return categories.ToList();
        }
    }
}
