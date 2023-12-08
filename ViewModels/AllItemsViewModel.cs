using System;
using System.Collections.ObjectModel;

namespace Firma.ViewModels
{
    public class ProductData
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public int StockStatus { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int WarehouseAvailability { get; set; }
    }

    public class AllItemsViewModel : WorkspaceViewModel
    {
        public ObservableCollection<ProductData> Products { get; set; }

        public AllItemsViewModel()
        {
            DisplayName = "Magazyn";
            Products = new ObservableCollection<ProductData>();

            var rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                Products.Add(new ProductData
                {
                    ProductNumber = i+1,
                    ProductName = "Krówki Mleczne typu " + i,
                    Manufacturer = "Mlekowita ",
                    StockStatus = rnd.Next(10, 50),
                    PurchasePrice = (decimal)(rnd.NextDouble() * 100.0),
                    SalePrice = (decimal)(rnd.NextDouble() * 100.0),
                    ExpiryDate = DateTime.Now.AddDays(rnd.Next(100)),
                    WarehouseAvailability = rnd.Next(10, 50)
                });
            }
        }
    }
}
