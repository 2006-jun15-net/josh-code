using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenServiceRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KitchenServiceRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private static List<FoodItem> foodItems = new List<FoodItem>
        {
            new FoodItem {Id = 1, Name = "Cheese", ExpirationDate = new DateTime(2020, 7, 15)}
        };

        // GET: api/Fridge/items
        [HttpGet("items")]
        public IEnumerable<FoodItem> GetItems()
        {
            //yield return new FoodItem
            //{
            //    Id = 1,
            //    Name = "Apple",
            //    ExpirationDate = DateTime.Now
            //};
            return foodItems;
        }

        // GET api/Fridge/items/5
        [HttpGet("items/{id}")]
        public FoodItem GetItem(int id)//get a specific food item
        {
            //return new FoodItem
            //{
            //    Id = id,
            //    Name = "Orange",
            //    ExpirationDate = DateTime.Now
            //};
            return foodItems.First(i => i.Id == id);
        }

        // POST api/Fridge/items
        [HttpPost]
        public IActionResult Post([FromBody] FoodItem item)//create new food item
        {
            if(foodItems.Any(x => x.Id == item.Id))
            {
                return Conflict();
            }
            foodItems.Add(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPost("clean")]
        public void Clean()
        {

        }

        // PUT api/Fridge/items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if(foodItems.FirstOrDefault(item => item.Id == id) != null)
            {
                var selectedUpdateItem = foodItems.FirstOrDefault(item => item.Id == id);
                //return //204 or 200
            }
            
        }

        // DELETE api/Fridge/items/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //chek if id exists
            //return 204(no content) if successful
        }
    }
}
