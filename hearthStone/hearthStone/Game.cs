using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Game
    {
        public int Crystal1 { get; set; }
        public int Crystal2 { get; set; }
        public int Timelimit1 { get; private set; }
        public int Timelimit2 { get; private set; }
        public Tuple<Hero,Hero> THero { get; }
        public Tuple<List<Card>,List<Card>> THand { get; }
        public Tuple<List<Card>, List<Card>> TLibrary { get; }
        public Tuple<List<Card>, List<Card>> TGround { get; }
        public bool Whichuser { get; set; } //true indicate first user, false indicate second user
        public bool Rerendering { get; set; }
        public List<IAction> Actionpool { get; private set; }

        public Game(Tuple<List<Card>, List<Card>> tlibrary)
        {
            Crystal1 = 0;
            Crystal2 = 0;
            Timelimit1 = 60;
            Timelimit2 = 60;
            THero = new Tuple<Hero, Hero>(new Hero(30, "fbb"), new Hero(30,"wyq"));
            THand = new Tuple<List<Card>, List<Card>>(new List<Card>(), new List<Card>());
            TLibrary = tlibrary;
            TGround = new Tuple<List<Card>, List<Card>>(new List<Card>(), new List<Card>());
            Whichuser = true;
            Rerendering = false;
            Actionpool = new List<IAction>();
        }
    
       
       public bool player1win()
       {
            return THero.Item1.Hp >0 && THero.Item2.Hp <= 0;
       }

       public bool player2win()
       {
            return THero.Item2.Hp > 0 && THero.Item1.Hp <= 0;
       }
       
       public void init()
       {
            Card card = TLibrary.Item1[0];
            THand.Item1.Add(card);
            TLibrary.Item1.RemoveAt(0);
            Crystal1++;
            Rerendering = true;
       }

        public void loop()
       {
            while (!player1win() && !player2win())
            {
                if (Actionpool.Any())
                {
                    IAction action = Actionpool[0];
                    Actionpool.RemoveAt(0);
                    action.perform();
                    Rerendering = true;
                }
            }
        }
   
        static void Main(string[] args)
        {
            InitCardsIntoXml initCardsIntoXml = new InitCardsIntoXml();
            List<Card> card1 = initCardsIntoXml.getAllCards();
            List<Card> card2 = initCardsIntoXml.getAllCards();
            Game game = new Game(new Tuple<List<Card>, List<Card>>(card1,card2));
            // init GUi thread
            game.init();
            game.loop();
            if (game.player1win())
            {
                // print player1 win
            }
            else if (game.player2win())
            {
                // print player2 win
            }
            Console.ReadKey(true);
        }

    }
}
