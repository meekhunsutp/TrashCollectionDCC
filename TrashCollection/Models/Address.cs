using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Street Address")]

        public string StreetAddress { get; set; }
        [Display(Name = "City, State")]

        public string CityState { get; set; }
        [Display(Name = "Zip Code")]

        public int Zip { get; set; }


    }
}
