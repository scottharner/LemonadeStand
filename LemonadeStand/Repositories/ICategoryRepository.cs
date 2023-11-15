using LemonadeStand.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> AllCategories { get; }
}