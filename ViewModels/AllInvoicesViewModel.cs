using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class InvoiceData
    {
        public string InvoiceNumber { get; set; }
        public string ClientName { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentDate { get; set; }
        public string IsPaid { get; set; }
    }

    public class AllInvoicesViewModel : WorkspaceViewModel
    {
        public ObservableCollection<InvoiceData> Invoices { get; set; }

        public AllInvoicesViewModel()
        {
            DisplayName = "Faktury";
            Invoices = new ObservableCollection<InvoiceData>
            {
                new InvoiceData {InvoiceNumber = "12345", ClientName = "Klient1", PaymentAmount = "500.00", PaymentDate = "2023-05-21", IsPaid = "Tak"},
                new InvoiceData {InvoiceNumber = "12346", ClientName = "Klient2", PaymentAmount = "750.00", PaymentDate = "2023-05-20", IsPaid = "Nie"},
                new InvoiceData {InvoiceNumber = "12347", ClientName = "Klient3", PaymentAmount = "900.00", PaymentDate = "2023-05-19", IsPaid = "Tak"},
                new InvoiceData {InvoiceNumber = "12348", ClientName = "Klient4", PaymentAmount = "600.00", PaymentDate = "2023-05-22", IsPaid = "Tak"},
                new InvoiceData {InvoiceNumber = "12349", ClientName = "Klient5", PaymentAmount = "800.00", PaymentDate = "2023-05-23", IsPaid = "Nie"},
                new InvoiceData {InvoiceNumber = "12350", ClientName = "Klient6", PaymentAmount = "1200.00", PaymentDate = "2023-05-24", IsPaid = "Tak"},
                new InvoiceData {InvoiceNumber = "12351", ClientName = "Klient7", PaymentAmount = "500.00", PaymentDate = "2023-05-25", IsPaid = "Tak"},
                new InvoiceData {InvoiceNumber = "12352", ClientName = "Klient8", PaymentAmount = "900.00", PaymentDate = "2023-05-26", IsPaid = "Nie"},
                new InvoiceData {InvoiceNumber = "12353", ClientName = "Klient9", PaymentAmount = "750.00", PaymentDate = "2023-05-27", IsPaid = "Tak"},
                new InvoiceData {InvoiceNumber = "12354", ClientName = "Klient10", PaymentAmount = "1000.00", PaymentDate = "2023-05-28", IsPaid = "Nie"}
            };
        }
    }
}
