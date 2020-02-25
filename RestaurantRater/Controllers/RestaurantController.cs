using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _dbContext = new RestaurantDbContext();

        //POST
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant != null)
            {
                _dbContext.Restaurants.Add(restaurant);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }

        //GET ALL
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //GET BY ID
        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurantById(int id)
        {
            Restaurant restaurant = await _dbContext.Restaurants.FindAsync(id);

            if (restaurant != null)
                return Ok(restaurant);
            else
                return NotFound();
        }

        //PUT
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant model)
        {
            if (ModelState.IsValid && model != null)
            {
                Restaurant restaurant = await _dbContext.Restaurants.FindAsync(id);
                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Style = model.Style;
                    restaurant.Rating = model.Rating;
                    restaurant.DollarSigns = model.DollarSigns;

                    await _dbContext.SaveChangesAsync();

                    return Ok();
                }
                else
                    return NotFound();
            }
            else
                return BadRequest(ModelState);
        }

        //DELETE BY ID
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurant(int id)
        {
            Restaurant restaurant = _dbContext.Restaurants.Find(id);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            else
                return NotFound();
        }
    }
}