using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace RestaurantManagement.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Location { get; set; }

        [Required]
        [Range(1,5)]
        public short Rating { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
