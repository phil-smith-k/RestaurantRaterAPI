using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        [Range(0.0, 5.0)]
        public double Rating { get; set; }

        [Required]
        [Range(1, 5)]
        public int DollarSigns { get; set; }
    }
}