namespace RestaurantReviewAPI.Models;

public class Review
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public int Stars { get; set; }
}
