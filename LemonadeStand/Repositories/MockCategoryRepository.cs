using LemonadeStand.Models;

public class MockCategoryRepository : ICategoryRepository
{
    public IEnumerable<Category> AllCategories => 
    new List<Category>
    {
        new Category { CategoryId = 1, Name = "Lemony", Description = "Assorted Varieties of Lemonade" },
        new Category { CategoryId = 2, Name = "Sweet", Description = "Non-Lemon Beverages to Satisfy Your Sweet Tooth"}
    };
}