using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hearthStone_GUI
{
    public partial class HearthStoneInterface : Form
    {
        private List<Card> _my_hand_card_list;
        private List<Card> _my_bat_card_list;
        private Hero _my_hero;
        private List<Card_Slot> _my_hand_card_slots;
        private List<Card_Slot> _my_bat_card_slots;

        private List<Card> _opp_hand_card_list;
        private List<Card> _opp_bat_card_list;
        private Hero _opp_hero;
        private List<Card_Slot> _opp_hand_card_slots;
        private List<Card_Slot> _opp_bat_card_slots;

        enum Last_Click_Card_Type
        {
            MY_HAND,
            MY_BAT,
            OPP_HAND,
            OPP_BAT
        }
        Last_Click_Card_Type last_click_type;
        private Card_Slot pre_click_card_slot;

        public HearthStoneInterface()
        {
            InitializeComponent();

            _my_hand_card_slots = new List<Card_Slot>();
            _my_bat_card_slots = new List<Card_Slot>();

            _opp_hand_card_slots = new List<Card_Slot>();
            _opp_bat_card_slots = new List<Card_Slot>();

            string[] suffixes = {"_crystal", "_attack", "_hp" };

            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    if (!btn.Name.Contains("card")) continue;
                    var card_slot = new Card_Slot();
                    card_slot.btn = btn;

                    for(int i = 0; i < suffixes.Length; i++)
                    {
                        Control[] controls = Controls.Find(btn.Name + suffixes[i], false);
                        Label label = (Label)controls[0];
                        switch (i)
                        {
                            case 0:
                                card_slot.crystal = label;
                                break;
                            case 1:
                                card_slot.attack = label;
                                break;
                            case 2:
                                card_slot.hp = label;
                                break;
                        }
                    }
                    if (btn.Name.Contains("my"))
                    {
                        if (btn.Name.Contains("hand"))
                        {
                            _my_hand_card_slots.Add(card_slot);
                        }
                        else
                        {
                            _my_bat_card_slots.Add(card_slot);
                        }
                    }
                    else
                    {
                        if (btn.Name.Contains("hand"))
                        {
                            _opp_hand_card_slots.Add(card_slot);
                        }
                        else
                        {
                            _opp_bat_card_slots.Add(card_slot);
                        }
                    }
                }
            }

            _my_hand_card_slots.Sort();
            _my_bat_card_slots.Sort();
            _opp_hand_card_slots.Sort();
            _opp_bat_card_slots.Sort();
        }

        private void HearthStoneInterface_Load(object sender, EventArgs e)
        {
            ActiveControl = opp_hero_name_label;
        }

        private void my_bat_card_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var card_slot = _my_bat_card_slots[get_button_id(btn) - 1];
            if(pre_click_card_slot == null)
            {
                pre_click_card_slot = card_slot;
                last_click_type = Last_Click_Card_Type.MY_BAT;
                return;
            }
            if (pre_click_card_slot == card_slot)
                return;

            switch (last_click_type)
            {
                case Last_Click_Card_Type.MY_BAT:
                    MessageBox.Show("I move battle card " + pre_click_card_slot.id + " to battle card " + card_slot.id);
                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
                case Last_Click_Card_Type.MY_HAND:
                    MessageBox.Show("I move hand card " + pre_click_card_slot.id + " to battle card " + card_slot.id);

                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
                case Last_Click_Card_Type.OPP_BAT:
                    MessageBox.Show("opponent battle card " + pre_click_card_slot.id + " attack my battle card " + card_slot.id);
                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
                case Last_Click_Card_Type.OPP_HAND:
                    // ignore this case
                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
            }

        }

        private void my_hand_card_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var card_slot = _my_hand_card_slots[get_button_id(btn) - 1];
            pre_click_card_slot = card_slot;
            last_click_type = Last_Click_Card_Type.MY_HAND;
        }


        private void opp_bat_card_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var card_slot = _opp_bat_card_slots[get_button_id(btn) - 1];
            if (pre_click_card_slot == null)
            {
                pre_click_card_slot = card_slot;
                last_click_type = Last_Click_Card_Type.OPP_BAT;
                return;
            }
            if (pre_click_card_slot == card_slot)
                return;

            switch (last_click_type)
            {
                case Last_Click_Card_Type.MY_BAT:
                    MessageBox.Show("my battle card " + pre_click_card_slot.id + " attack opponent battle card " + card_slot.id);
                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
                case Last_Click_Card_Type.MY_HAND:
                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
                case Last_Click_Card_Type.OPP_BAT:
                    MessageBox.Show("oppent move battle card " + pre_click_card_slot.id + " to battle card " + card_slot.id);
                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
                case Last_Click_Card_Type.OPP_HAND:
                    MessageBox.Show("opponent move hand card " + pre_click_card_slot.id + " to battle card " + card_slot.id);
                    pre_click_card_slot = null;
                    ActiveControl = opp_hero_name_label;
                    break;
            }

        }

        private void opp_hand_card_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var card_slot = _opp_hand_card_slots[get_button_id(btn) - 1];
            pre_click_card_slot = card_slot;
            last_click_type = Last_Click_Card_Type.OPP_HAND;
        }

        private void my_hero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (pre_click_card_slot != null)
            {
                if(last_click_type == Last_Click_Card_Type.OPP_BAT)
                {
                    MessageBox.Show("Oppponent battle card " + pre_click_card_slot.id + " attack my hero!");
                }
            }

            pre_click_card_slot = null;
            ActiveControl = opp_hero_name_label;
        }

        private void opp_hero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (pre_click_card_slot != null)
            {
                if (last_click_type == Last_Click_Card_Type.MY_BAT)
                {
                    MessageBox.Show("My battle card " + pre_click_card_slot.id + " attack opponent hero!");
                }
            }

            pre_click_card_slot = null;
            ActiveControl = opp_hero_name_label;
        }

        private int get_button_id(Button btn)
        {
            return Convert.ToInt32(btn.Name.Substring(btn.Name.LastIndexOf('_') + 1));
        }


    }

    public class Card
    {
        public int Crystalcost { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public bool Sleep { get; set; }
        public Card(int crystalcost, int hp, int attack)
        {
            Crystalcost = crystalcost;
            Hp = hp;
            Attack = attack;
            Sleep = true;
        }
    }

    public class Hero
    {
        public int Hp { get; set; }
        public String Name { get; set; }
        public Hero(int hp, String name)
        {
            Hp = hp;
            Name = name;
        }
    }

    public class Game
    {
        public int Crystal1 { get; private set; }
        public int Crystal2 { get; private set; }
        public int Timelimit1 { get; private set; }
        public int Timelimit2 { get; private set; }
        public Tuple<Hero, Hero> THero { get; }
        public Tuple<List<Card>, List<Card>> THand { get; }
        public Tuple<List<Card>, List<Card>> TLibrary { get; }
        public Tuple<List<Card>, List<Card>> TGround { get; }
        public bool Whichuser { get; private set; } //true indicate first user, false indicate second user
    }


    public class Card_Slot: IComparable
    {
        public Card card;
        public Button btn;
        public Label crystal;
        public Label hp;
        public Label attack;

        public Card_Slot()
        {
            card = null;
        }

        public int id
        {
            get
            {
                return Convert.ToInt32(btn.Name.Substring(btn.Name.LastIndexOf('_') + 1));
            }
        }

        public void reset()
        {
            if(card == null)
            {
                btn.FlatStyle = FlatStyle.Flat;
                crystal.Hide();
                hp.Hide();
                attack.Hide();
            }
            else
            {
                crystal.Text = card.Crystalcost.ToString();
                hp.Text = card.Hp.ToString();
                attack.Text = card.Attack.ToString();
                btn.FlatStyle = FlatStyle.Standard;
                crystal.Show();
                hp.Show();
                attack.Show();
            }
        }

        public int CompareTo(object obj)
        {
            var rhs = (Card_Slot)obj;
            if (id < rhs.id)
                return -1;
            else
                return 1;
        }
    }

}
