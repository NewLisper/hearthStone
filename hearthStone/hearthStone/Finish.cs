using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Finish : IAction
    {
        private Game RGame { get; set; }
        public Finish(Game game)
        {
            RGame = game;
        }
        private void initcard(List<Card> library, List<Card> hand, List<Card> ground)
        {
            Card card = library[0];
            hand.Add(card);
            library.RemoveAt(0);
            ground.ForEach(minion => minion.Sleep = false);
        }
        public void perform()
        {
            if (RGame.Whichuser)
            {
                initcard(RGame.TLibrary.Item1, RGame.THand.Item1, RGame.TGround.Item1);
                if (RGame.Crystal1 < 10) RGame.Crystal1++;
            }
            else
            {
                initcard(RGame.TLibrary.Item2, RGame.THand.Item2, RGame.TGround.Item2);
                if (RGame.Crystal2 < 10) RGame.Crystal2++;
            }
            RGame.Whichuser = !RGame.Whichuser;
        }
    }
}
