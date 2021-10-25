using System;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split(' ');
            string[] urls = Console.ReadLine().Split(' ');

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in phones)
            {
                try
                {
                    switch (number.Length)
                    {
                        case 7: Console.WriteLine(stationaryPhone.Call(number)); break;
                        case 10: Console.WriteLine(smartphone.Call(number)); break;
                        default: throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidUrlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
