using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Cancellation
    {
        public int CancelID { get; set; }             
        public int BookingID { get; set; }             
        public bool TicketCancelled { get; set; }      
        public decimal RefundAmount { get; set; }      
        public DateTime DateOfCancellation { get; set; }
    }

}
