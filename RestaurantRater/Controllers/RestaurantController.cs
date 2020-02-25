using RestaurantRater.Models;
using System;
using System.Collections.Generic;
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
    }
}