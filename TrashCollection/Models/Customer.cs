using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName  { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Balance Due")]
        [DisplayFormat(NullDisplayText = "Current", DataFormatString = "{0:c}")]
        [DefaultValue(0)]
        public double AccountBalance { get; set; }

        [Display(Name = "Confirm Pick Up")]
        public bool CustomerConfirmPickUp { get; set; }

        [Required]
        [Display(Name = "Collection Day")]
        public DayOfWeek CollectionDay { get; set; }

        [Display(Name = "Request Extra Pick Up Date")]
        [DataType(DataType.Date)]
        public DateTime? ExtraPickUp { get; set; }

        [Display(Name = "Pause Service Start Date")]
        [DataType(DataType.Date)]
        public DateTime? SuspendServiceStart { get; set; }

        [Display(Name = "Pause Service End Date")]
        [DataType(DataType.Date)]
        public DateTime? SuspendServiceEnd { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
    }
}
