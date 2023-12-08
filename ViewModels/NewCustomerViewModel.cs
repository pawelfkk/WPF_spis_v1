using Firma.Models;
using Firma.ViewResources;
using System;
using System.Collections.ObjectModel;

namespace Firma.ViewModels
{
    public class NewCustomerViewModel : WorkspaceViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public NewCustomerViewModel()
        {
            DisplayName = GlobalResources.NowyKontrahent;

            Customers = new ObservableCollection<Customer>();

            for (int i = 1; i <= 5; i++)
            {
                Customers.Add(new Customer(
                    "1234567890", 
                    "1234567890", 
                    true, 
                    "Imię " + i, 
                    "Osoba kontaktowa " + i, 
                    "email" + i + "@onet.com", 
                    DateTime.Now,
                    "123456789"

                ));
            }

        }
    }
}
