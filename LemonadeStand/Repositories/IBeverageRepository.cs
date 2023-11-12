public interface IBeverageRepository
{
    IEnumerable<Beverage> AllBeverages { get; }
    IEnumerable<Beverage> FeaturedBeverages { get; }
    Beverage? GetBeverageById(int beverageId);
}