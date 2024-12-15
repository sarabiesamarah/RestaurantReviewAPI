using Microsoft.AspNetCore.Mvc;
using RestaurantReviewAPI.Data;
using RestaurantReviewAPI.Models;

namespace RestaurantReviewAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RestaurantController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Restaurant
    [HttpGet]
    public IActionResult GetRestaurants()
    {
        var restaurants = _context.Restaurants.ToList();
        return Ok(restaurants);
    }

    // GET: api/Restaurant/{id}
    [HttpGet("{id}")]
    public IActionResult GetRestaurantById(int id)
    {
        var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    // POST: api/Restaurant
    [HttpPost]
    public IActionResult AddRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurant.Id }, restaurant);
    }

    // PUT: api/Restaurant/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateRestaurant(int id, Restaurant updatedRestaurant)
    {
        var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);
        if (restaurant == null)
        {
            return NotFound();
        }

        restaurant.Name = updatedRestaurant.Name;
        restaurant.Location = updatedRestaurant.Location;
        restaurant.CuisineType = updatedRestaurant.CuisineType;
        restaurant.Rating = updatedRestaurant.Rating;

        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Restaurant/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteRestaurant(int id)
    {
        var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);
        if (restaurant == null)
        {
            return NotFound();
        }

        _context.Restaurants.Remove(restaurant);
        _context.SaveChanges();
        return NoContent();
    }
}
