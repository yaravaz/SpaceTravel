using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetravel.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int User { get; set; }
        public string Name { get; set; }
        public Tour? Tour { get; set; }
        public Mission? Mission { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public bool IsActive {  get; set; }
        public bool IsApproved {  get; set; }
    }
}
