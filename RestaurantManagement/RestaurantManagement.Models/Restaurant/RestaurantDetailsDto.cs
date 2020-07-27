using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models.Restaurant
{
    public class RestaurantDetailsDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Range(1, 5)]
        public short Rating { get; set; }
    }
}
