namespace RestaurantReviewAPI.Models
{
    public class Restaurant
    {
        public int Id { get; set; } = 0;          // Default for primary key
        public string Name { get; set; } = "";    // Avoid null issues
        public string Location { get; set; } = ""; // Default value for Location
        public string Cuisine { get; set; } = "";  // Default value for Cuisine
        public double Rating { get; set; } = 0.0; // Default rating
    }
}

