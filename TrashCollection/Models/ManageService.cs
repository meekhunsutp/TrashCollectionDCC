using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    public class ManageService
    {
        [Key]
        public int ServiceId { get; set; }

        public DayOfWeek ServiceDay { get; set; }
        public DateTime? ExtraPickUp { get; set; }
        public DateTime? SuspendServiceStart { get; set; }
        public DateTime? SuspendServiceEnd { get; set; }
        public double Cost { get; set; }
        public bool CustomerConfirmPickUp { get; set; }
        public bool EmployeeConfirmPickUp { get; set; }


    }
}
