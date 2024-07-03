using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetravel.Models
{
    public class Spaceship
    {
        public int SpaceshipID { get; set; }
        //[StringLength(20, ErrorMessage = "the length of the name cannot exceed 20 characters")]
        public string Name { get; set; }
        //[StringLength(500, ErrorMessage = "the length of the description cannot exceed 500 characters")]
        public string Description { get; set; }
        //[Range(0, short.MaxValue, ErrorMessage = "wrong capacity")]
        public short Capacity { get; set; }
        //[Range(0, float.MaxValue, ErrorMessage = "wrong height")]
        public float Height { get; set; }
        //[Range(0, float.MaxValue, ErrorMessage = "wrong diameter")]
        public float Diameter { get; set; }
        //[Range(0, float.MaxValue, ErrorMessage = "wrong payload capacity")]
        public float PayloadCapacity { get; set; }

        public Spaceship(string name, string description, short capacity, float height, float diameter, float payloadCapacity)
        {
            Name = name;
            Description = description;
            Capacity = capacity;
            Height = height;
            Diameter = diameter;
            PayloadCapacity = payloadCapacity;
        }
    }
}
