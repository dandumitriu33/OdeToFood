using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            // SearchTerm = searchTerm; // can work
            // HttpContext.Request.QueryString // one way of getting the searchTerm
            // with strings searchTerm from parameters is optional, it won't throw exception
            // if it's an int it will throw an exception
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}