using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace hearthStone
{
    class InitCardsIntoXml
    {
        private static String fileLocation = "..//..//cards.xml";
        public static IEnumerable<XElement> getAllCards()
        {
            XDocument doc = XDocument.Load(fileLocation);
            IEnumerable<XElement> cardsList =
                from c in doc.Root.Elements()
                select c;
            return cardsList;

        }
        public static void InitCards() {
            XDocument card = new XDocument(
                new XComment("cards information."),
                new XProcessingInstruction("xml-stylesheet",
                                 "href='mystyle.css' title='Compact' type='text/css'"),
                new XElement("Cards",
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "1"),
                         new XElement("Attack", "2"),
                         new XElement("Hp", "1")
                     ),
                    new XElement("JiaoXiaoZhongShi",
                         new XElement("Crystal", "1"),
                         new XElement("Attack", "2"),
                         new XElement("Hp", "1")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "2"),
                         new XElement("Attack", "2"),
                         new XElement("Hp", "3")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "2"),
                         new XElement("Attack", "3"),
                         new XElement("Hp", "2")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "2"),
                         new XElement("Attack", "2"),
                         new XElement("Hp", "3")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "3"),
                         new XElement("Attack", "3"),
                         new XElement("Hp", "4")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "3"),
                         new XElement("Attack", "3"),
                         new XElement("Hp", "4")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "3"),
                         new XElement("Attack", "4"),
                         new XElement("Hp", "3")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "4"),
                         new XElement("Attack", "4"),
                         new XElement("Hp", "5")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "4"),
                         new XElement("Attack", "5"),
                         new XElement("Hp", "4")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "5"),
                         new XElement("Attack", "5"),
                         new XElement("Hp", "6")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "5"),
                         new XElement("Attack", "6"),
                         new XElement("Hp", "5")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "6"),
                         new XElement("Attack", "6"),
                         new XElement("Hp", "7")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "6"),
                         new XElement("Attack", "7"),
                         new XElement("Hp", "6")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "6"),
                         new XElement("Attack", "6"),
                         new XElement("Hp", "7")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "7"),
                         new XElement("Attack", "7"),
                         new XElement("Hp", "8")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "7"),
                         new XElement("Attack", "7"),
                         new XElement("Hp", "8")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "7"),
                         new XElement("Attack", "8"),
                         new XElement("Hp", "7")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "8"),
                         new XElement("Attack", "8"),
                         new XElement("Hp", "9")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "8"),
                         new XElement("Attack", "8"),
                         new XElement("Hp", "9")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "8"),
                         new XElement("Attack", "9"),
                         new XElement("Hp", "8")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "8"),
                         new XElement("Attack", "8"),
                         new XElement("Hp", "8")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "1"),
                         new XElement("Attack", "2"),
                         new XElement("Hp", "1")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "2"),
                         new XElement("Attack", "3"),
                         new XElement("Hp", "2")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "3"),
                         new XElement("Attack", "3"),
                         new XElement("Hp", "4")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "4"),
                         new XElement("Attack", "5"),
                         new XElement("Hp", "4")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "6"),
                         new XElement("Attack", "5"),
                         new XElement("Hp", "6")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "3"),
                         new XElement("Attack", "3"),
                         new XElement("Hp", "4")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "4"),
                         new XElement("Attack", "5"),
                         new XElement("Hp", "4")
                     ),
                    new XElement("NaiHaiChuanGong",
                         new XElement("Crystal", "6"),
                         new XElement("Attack", "5"),
                         new XElement("Hp", "6")
                     )
                ),
                new XComment("end of the cards.")
            );
            card.Declaration = new XDeclaration("1.0", "utf-8", "true");
            Console.WriteLine(card);
            card.Save(fileLocation);

        }
    }
}
