using LemonadeStand.Models;

namespace LemonadeStand.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LemonadeStandDbContext _lemonadeStandDbContext;

        public CategoryRepository(LemonadeStandDbContext lemonadeStandDbContext)
        {
            _lemonadeStandDbContext = lemonadeStandDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _lemonadeStandDbContext.Categories.OrderBy(c => c.Name);
    }
}
