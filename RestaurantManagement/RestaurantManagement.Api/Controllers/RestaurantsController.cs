using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Services;
using RestaurantManagement.Data;
using RestaurantManagement.Entities;
using RestaurantManagement.Models.Restaurant;

namespace RestaurantManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly ManagementDbContext _context;
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(ManagementDbContext context, IRestaurantService restaurantService)
        {
            _context = context;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDetailsDto>>> GetAll()
        {
            return Ok(await _restaurantService.GetAll());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, RestaurantDetailsDto restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            var result = await _restaurantService.Edit(restaurant);

            return result ? (IActionResult)NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDetailsDto>> Get(int id)
        {
            var restaurant = await _restaurantService.Find(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantDetailsDto>> Add(RestaurantDetailsDto restaurant)
        {
            var result = await _restaurantService.Add(restaurant);

            return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RestaurantDetailsDto>> Delete(int id)
        {
            var restaurant = await _restaurantService.Delete(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }
    }
}
