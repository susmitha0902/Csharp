using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Reservation
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public string TrainNo { get; set; }
        public int TrainID { get; set; }
        public string PassengerName { get; set; }
        public DateTime DateOfTravel { get; set; }
        public string Class { get; set; }
        public string BerthAllotment { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime DateOfBooking { get; set; }
        public bool WaitListStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
