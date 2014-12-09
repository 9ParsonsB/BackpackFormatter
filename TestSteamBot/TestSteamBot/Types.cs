using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSteamBot
{

    public class TFItem
    {
        public string Name;
        public string Price;
        public string Currency = "ref";
        public string From;

        public TFItem(string _Name, string _Price)
        {
            Name = _Name;
            Price = _Price;
        }
        public TFItem(string _Name, string _Price, string _Currency, string _From)
        {
            Name = _Name;
            Price = _Price;
            From = _From;

            switch (_Currency)
            {
                case "ref":
                    Currency = _Currency;
                    break;
                case "USD":
                    Currency = _Currency;
                    break;
                case "keys":
                    Currency = _Currency;
                    break;
                default:
                    Console.WriteLine("Currency not recognised for {0}. Defaulting to ref", _Name);
                    Currency = "ref";
                    break;
            }

        }

    }

}
