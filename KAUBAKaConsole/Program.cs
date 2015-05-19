using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace KAUBAKaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Console.WriteLine("Write \"info\" to get a list of commands");
            while (!quit)
            {
                string arg = Console.ReadLine();
                if (arg != null && arg.Equals("quit"))
                {
                    quit = true;
                }
                if (arg != null && arg.StartsWith("start"))
                {
                    if (arg.Length >= 6)
                    {
                        /* removes the start argument and the space */
                        string newArg = arg.Remove(0, 6);
                        if (newArg.StartsWith("create customer"))
                        {
                            string customerStr = newArg.Remove(0, 15);

                            //var customerArr = customerStr.Split(',');

                            /* Til test */
                            var _customerArr = new string[8];
                            _customerArr[0] = "Testname";
                            _customerArr[1] = "01-01-1980";
                            _customerArr[2] = "Test street";
                            _customerArr[3] = "9000";
                            _customerArr[4] = "Aalborg";
                            _customerArr[5] = "test@test.dk";
                            _customerArr[6] = "12345678";
                            _customerArr[7] = "010180-1234";

                            CustomerBusinessLogic.CreateCustomer(
                                _customerArr[0],
                                DateTime.ParseExact(_customerArr[1], "dd-MM-yyyy", null),
                                _customerArr[2],
                                _customerArr[3],
                                _customerArr[4],
                                _customerArr[5],
                                _customerArr[6],
                                _customerArr[7]);
                        }
                        else if (newArg.StartsWith("create account"))
                        {
                            string accountStr = newArg.Remove(0, 15);
                            var details = accountStr.Split(',');
                            AccountsBusinessLogic.AddAccount(details[0], double.Parse(details[1]), double.Parse(details[2]), details[3], double.Parse(details[4]));
                        }
                        else if (newArg.StartsWith("get account"))
                        {
                            string accountNo = newArg.Remove(0, 12);
                        }
                        else if (newArg.StartsWith("get customer"))
                        {
                            string customerSsn = newArg.Remove(0, 13);
                            var customer = CustomerBusinessLogic.GetCustomer(customerSsn);
                            if(customer == null)
                                Console.WriteLine("This customer does not exist!");
                            else
                                Console.WriteLine(customer.CustomerAsString);
                        }
                    }
                }
            }
        }
    }
}
