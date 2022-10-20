using System;
using System.Collections.Generic;

namespace CarSalesMVC.Models
{
    public partial class Advertisement
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int Price { get; set; }
        public virtual Car? Car { get; set; }
    }
}
