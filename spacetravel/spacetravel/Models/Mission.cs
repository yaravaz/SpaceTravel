using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetravel.Models
{
    public class Mission
    {
        public int MissionID { get; set; }
        //[StringLength(20, ErrorMessage = "the length of the name cannot exceed 20 characters")]
        public string Name { get; set; }
        //[StringLength(500, ErrorMessage = "the length of the description cannot exceed 500 characters")]
        public string Description { get; set; }
        //[Range(0, short.MaxValue, ErrorMessage = "wrong duration")]
        public short Duration { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "wrong altitude")]
        public int Altitude { get; set; }
        //[Range(0, float.MaxValue, ErrorMessage = "wrong price")]
        public float Price { get; set; }
        public Spaceship Spaceship { get; set; }
    }
}
