using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarSalesMVC.Models
{
    public partial class Car
    {
        public Car()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }
        public string CarName { get; set; } = null!;
        public double Odometer { get; set; }
        public string Engine { get; set; } = null!;
        public string? Description { get; set; }
        public string? Colour { get; set; }

        public Car GetCarDto()
        {
            Car car = new Car();
            car.CarName = CarName;
            car.Odometer = Odometer;
            car.Engine = Engine;
            car.Description = Description;
            car.Colour = Colour;

            return car;
        }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
