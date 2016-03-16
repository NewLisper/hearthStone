using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Game
    {
        public int Crystal1 { get; private set; }
        public int Crystal2 { get; private set; }
        public int Timelimit1 { get; private set; }
        public int Timelimit2 { get; private set; }
        public Tuple<Hero,Hero> THero { get; }
        public Tuple<List<Card>,List<Card>> THand { get; }
        public Tuple<List<Card>, List<Card>> TLibrary { get; }
        public Tuple<List<Card>, List<Card>> TGround { get; }
        public bool Whichuser { get; private set; } //true indicate first user, false indicate second user

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
        }
    
       private void initcard(List<Card> library, List<Card> hand, List<Card> ground)
       {
            Card card = library[0];
            hand.Add(card);
            library.RemoveAt(0);
            ground.ForEach(minion => minion.Sleep = false);
       }

       public void nextround()
       {
            int timelimit;
            if (Whichuser)
            {
                initcard(TLibrary.Item1, THand.Item1, TGround.Item1);
                if(Crystal1 < 10) Crystal1++;
                timelimit = Timelimit1;
            }
            else
            {
                initcard(TLibrary.Item2, THand.Item2, TGround.Item2);
                if (Crystal2 < 10) Crystal2++;
                timelimit = Timelimit2;
            }
         

            Whichuser = !Whichuser;
       }

        static void Main(string[] args)
        {
            Hero h1 = new Hero(30, "LL");
            Console.WriteLine(h1.Hp);
            Console.ReadKey(true);
        }

    }
}
