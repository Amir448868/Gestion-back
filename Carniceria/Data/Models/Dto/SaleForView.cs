namespace Carniceria.Data.Models.Dto
{
    public class SaleForView
    {
        public int id { get; set; }

        public string productName { get; set; }

        public int total { get; set; }

        public int amount { get; set; }

        public int price { get; set; }

        public string dateForView { get; set; }    
    }
}
