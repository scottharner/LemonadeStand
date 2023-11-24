using LemonadeStand.Models;
using Microsoft.EntityFrameworkCore;

namespace LemonadeStand.Repositories
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly LemonadeStandDbContext _lemonadeStandDbContext;

        public BeverageRepository(LemonadeStandDbContext lemonadeStandDbContext)
        {
            _lemonadeStandDbContext = lemonadeStandDbContext;
        }   

        public IEnumerable<Beverage> AllBeverages
        {
            get
            {
                return _lemonadeStandDbContext.Beverages.Include(b => b.Category);
            }
        }

        public IEnumerable<Beverage> FeaturedBeverages
        {
            get
            {
                return _lemonadeStandDbContext.Beverages.Include(p => p.Category)
                    .Where(p => p.IsFeatured);
            }
        }

        public Beverage? GetBeverageById(int beverageId)
        {
            return _lemonadeStandDbContext.Beverages.SingleOrDefault(b => b.BeverageId == beverageId);
        }
    }
}
