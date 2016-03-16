using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace hearthStone
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitCardsIntoXml.InitCards();
            IEnumerable<XElement> cardsList  = InitCardsIntoXml.getAllCards();
            Console.WriteLine(cardsList.Count());
            foreach (XElement e in cardsList)
                Console.WriteLine(e.Element("Crystal"));
            Console.ReadLine();
        }
    }
}
