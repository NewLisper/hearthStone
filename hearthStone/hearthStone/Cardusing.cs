using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hearthStone
{
    class Cardusing : IAction
    {
        private Game RGame { get; set; }
        private int Indexhand { get; set; }
        private int Indexground { get; set; }
        public Cardusing(Game game, int indexhand, int indexground)
        {
            RGame = game;
            Indexhand = indexhand;
            Indexground = indexground;
        }
        public void perform()
        {
            List<Card> hand,ground;
            if (RGame.Whichuser)
            {
                hand = RGame.THand.Item1;
                ground = RGame.THand.Item1;
            }
            else
            {
                hand = RGame.THand.Item2;
                ground = RGame.TGround.Item2;
            }
            Card usingcard = hand[Indexhand];
            hand.RemoveAt(Indexhand);
            ground.Insert(Indexground, usingcard);
        }
    }
}
