using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogicLayer
{
    public class CustomerBusinessLogic
    {
        public static void CreateCustomer(string name, DateTime dateOfBirth, string street, string zipcode, string city, string email, string phoneNo, string ssn)
        {
            CustomerDal.AddCustomer(name, dateOfBirth, street, zipcode, city, email, phoneNo, ssn);
        }
        public static Customer GetCustomer(string ssn)
        {
            var customerObj = CustomerDal.GetCustomer(ssn);
            if (customerObj != null)
            {
                var element = XElement.Parse(customerObj);
                Customer c = new Customer()
                {
                    Name = element.Attribute("name").Value.ToString(),
                    Email = element.Attribute("email").Value.ToString(),
                    City = element.Attribute("city").Value.ToString(),
                    DateOfBirth = Convert.ToDateTime(element.Attribute("dateOfBirth").Value.ToString()),
                    Street = element.Attribute("street").Value.ToString(),
                    ZipCode = element.Attribute("zipcode").Value.ToString(),
                    PhoneNo = element.Attribute("phoneNo").Value.ToString(),
                    SSN = element.Attribute("ssn").Value.ToString(),
                    CustomerAsString = customerObj
                };
                return c;
            }
            return null;
        }
    }
}
