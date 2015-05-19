using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class CustomerDal
    {
        private static string filename = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Data/Customers.xml");
        public static void AddCustomer(string name, DateTime dateOfBirth, string street, string zipcode, string city, string email, string phoneNo, string ssn)
        {
            var doc = XDocument.Load(filename);
            XElement customerElement = new XElement("customer");
            customerElement.Add(new XAttribute("name", name));
            customerElement.Add(new XAttribute("dateOfBirth", dateOfBirth));
            customerElement.Add(new XAttribute("street", street));
            customerElement.Add(new XAttribute("zipcode", zipcode));
            customerElement.Add(new XAttribute("city", city));
            customerElement.Add(new XAttribute("email", email));
            customerElement.Add(new XAttribute("phoneNo", phoneNo));
            customerElement.Add(new XAttribute("ssn", ssn));
            var xElement = doc.Element("customers");
            if (xElement != null) xElement.Add(customerElement);
            doc.Save(filename);
        }
        public static string GetCustomer(string ssn)
        {
            var doc = XDocument.Load(filename);
            if (doc.Descendants("customer").Count() > 0)
            {
                var obj = doc.Descendants("customer").Where(x => (string)x.Attribute("ssn") == ssn).FirstOrDefault().ToString();
                return obj;
            }
            return null;
        }
    }
}
