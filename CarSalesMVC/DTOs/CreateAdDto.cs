namespace CarSalesMVC.DTOs
{
    public class CreateAdDto
    {
        public string CarName { get; set; } = "";
        public double Odometer { get; set; } = 0;
        public string Engine { get; set; } = "";
        public string? Description { get; set; } = "";
        public string? Colour { get; set; } = "";
        public int Price { get; set; } = 0;
    }
}
