using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReservationSystem.Models
{
    public class Train
    {
        public int TrainID { get; set; }
        public string TrainNo { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Class { get; set; }
        public int TotalSeats{ get; set; }
        public int AvailableSeats{ get; set; }
        public decimal CostPerSeat { get; set; }

    }
}
