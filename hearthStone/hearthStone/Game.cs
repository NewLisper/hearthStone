using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Game
    {
        public Tuple<Hero,Hero> THero { get; private set; }
        public Tuple<int,int> TCrystal { get; private set; }
        public Tuple<int,int> TTimelimit { get; set; }
        public Tuple<List<Card>,List<Card>> THand { get; private set; }
        public Tuple<List<Card>, List<Card>> TLibrary { get; private set; }
        public Tuple<List<Card>, List<Card>> TGround { get; private set; }
        public bool Whichuser { get; private set; } //true indicate first user, false indicate second user

        public Game(Tuple<List<Card>, List<Card>> tlibrary)
        {
            THero = new Tuple<Hero, Hero>(new Hero(30, "fbb"), new Hero(30,"wyq"));
            TCrystal = new Tuple<int, int>(0, 0);
            TTimelimit = new Tuple<int, int>(60, 60);
            THand = new Tuple<List<Card>, List<Card>>(new List<Card>(), new List<Card>());
            TLibrary = tlibrary;
            TGround = new Tuple<List<Card>, List<Card>>(new List<Card>(), new List<Card>());
            Whichuser = true;
        }

        static void Main(string[] args)
        {
            InitCardsIntoXml initCardsIntoXml = new InitCardsIntoXml();
            List<Card> card1 = initCardsIntoXml.getAllCards();
            List<Card> card2 = initCardsIntoXml.getAllCards();
            Console.WriteLine(card2.Count());
            Game game = new Game(new Tuple<List<Card>, List<Card>>(card1,card2));
            Hero h1 = new Hero(30, "LL");
            Console.WriteLine(h1.Hp);
            Console.ReadKey(true);
        }

    }
}
