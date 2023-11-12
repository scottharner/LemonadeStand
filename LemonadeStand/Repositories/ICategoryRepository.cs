public interface ICategoryRepository
{
    IEnumerable<Category> AllCategories { get; }
}