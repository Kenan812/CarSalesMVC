using CarSalesMVC.DTOs;
using CarSalesMVC.Models;

namespace CarSalesMVC.ViewModels
{
    public class CreateAdViewModel
    {

        public Car Car { get; set; } = new Car();

        public CreateAdDto CreateAdDto { get; set; }

        public string ErrorMessage { get; set; } = "";

        private readonly car_salesContext _car_SalesContext;

        public CreateAdViewModel()
        {

        }
        public CreateAdViewModel(car_salesContext car_SalesContext)
        {
            _car_SalesContext = car_SalesContext;
        }


        public Status AddCarToDb(CreateAdDto dto)
        {
            if (String.IsNullOrEmpty(dto.CarName) || String.IsNullOrEmpty(dto.Engine) || dto.Price == 0)
            {
                ErrorMessage = "All field with '*' must be filled";
                return Status.Failure;
            }

            var newCar = new Car()
            {
                CarName = dto.CarName,
                Engine = dto.Engine,
                Description = dto.Description,
                Colour = dto.Colour,
                Odometer = dto.Odometer
            };

            Advertisement newAd = new Advertisement()
            {
                Car = newCar,
                Price = dto.Price
            };

            _car_SalesContext.Cars.Add(newCar);
            _car_SalesContext.Advertisements.Add(newAd);

            _car_SalesContext.SaveChanges();

            ErrorMessage = "Ok";
            return Status.Success;
        }
    }

    public enum Status
    {
        Success = 0,
        Failure
    }

}
