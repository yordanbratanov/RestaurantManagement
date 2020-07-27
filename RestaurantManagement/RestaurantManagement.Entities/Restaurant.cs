using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Location { get; set; }

        public short Rating { get; set; }
    }
}
