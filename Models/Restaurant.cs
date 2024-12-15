namespace RestaurantReviewAPI.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string CuisineType { get; set; } = string.Empty;
    public double Rating { get; set; }
    public List<Review> Reviews { get; set; } = new();
}
