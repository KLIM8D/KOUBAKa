using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public List<Account> Accounts { get; set; }

        public Customer()
        {
            Accounts = new List<Account>();
        }
    }
}
