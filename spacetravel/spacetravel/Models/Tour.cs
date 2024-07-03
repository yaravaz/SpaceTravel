using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace spacetravel.Models
{
    public class Tour
    {
        public int TourID { get; set; }
        //[StringLength(20, ErrorMessage= "the length of the name cannot exceed 20 characters")]
        public string Name { get; set; }
        //[StringLength(500, ErrorMessage = "the length of the description cannot exceed 500 characters")]
        public string Description { get; set; }
        //[StringLength(20, ErrorMessage = "the length of the address cannot exceed 20 characters")]
        public string Address { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        //[Range(0, float.MaxValue, ErrorMessage = "wrong price")]
        public float Price { get; set; }
        public string Image {  get; set; }
        public bool IsActive { get; set; }
    }
}
