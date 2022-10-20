using CarSalesMVC.Models;
using CarSalesMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Web;

namespace CarSalesMVC.Controllers
{
    public class HomeController : Controller
    {
        CreateAdViewModel _createAdViewModel;

        private readonly ILogger<HomeController> _logger;
        private car_salesContext _car_SalesContext = new car_salesContext();
        private readonly ViewCarAdsViewModel _viewCarAdsViewModel;
        public HomeController(car_salesContext car_SalesContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            _car_SalesContext = car_SalesContext;
            _createAdViewModel = new CreateAdViewModel(car_SalesContext);
            _viewCarAdsViewModel = new ViewCarAdsViewModel(_car_SalesContext);
        }

        public IActionResult Index()
        {
            return View(_viewCarAdsViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowDescription(string carname)
        {
            return View("Description", _car_SalesContext.Cars.Where(x=>x.CarName==carname).FirstOrDefault());
        }

        public IActionResult CreateAd()
        {
            return View("CreateAd", _createAdViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult AddCar(CreateAdViewModel createAdViewModel)
        {
            Status addStatus = _createAdViewModel.AddCarToDb(createAdViewModel.CreateAdDto);
            if (addStatus == Status.Failure)
            {
                return View("CreateAd", _createAdViewModel);
            }

            return View("Index", _viewCarAdsViewModel);
        }
    }
}