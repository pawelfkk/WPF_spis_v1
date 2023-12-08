using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models
{
    public class Customer
    {
        public string NIP { get; set; }
        public string REGON { get; set; }
        public bool CustomerActive { get; set; }
        public string Name1 { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string Mobile { get; set; }
        public Customer(string nip, string regon, bool customerActive, string name1, string contactPerson, string email, DateTime dateOfPayment, string mobile)
        {
            NIP = nip;
            REGON = regon;
            CustomerActive = customerActive;
            Name1 = name1;
            ContactPerson = contactPerson;
            Email = email;
            DateOfPayment = dateOfPayment;
            Mobile = mobile;
        }
    }

}
