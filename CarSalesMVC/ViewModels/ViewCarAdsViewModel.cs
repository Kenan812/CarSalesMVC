using CarSalesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSalesMVC.ViewModels
{
    public class ViewCarAdsViewModel
    {
        public List<Advertisement> Advertisements 
        { 
            get
            {
                if (_car_SalesContext == null) return new List<Advertisement>();
                
                return _car_SalesContext.Advertisements.Include(x=>x.Car).ToList();
            }
            set { } 
        }


        private readonly car_salesContext _car_SalesContext;

        public ViewCarAdsViewModel()
        {

        }
        public ViewCarAdsViewModel(car_salesContext car_SalesContext)
        {
            _car_SalesContext = car_SalesContext;
        }
    }
}
