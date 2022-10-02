using System;

namespace Activity
{
    interface Pokemon
    {
        bool Fainted { get; set; }
        string Attack { get; set; }
        int Health { get; set; }
    }

    class Mudkip : Pokemon
    {
        public delegate void SendOut(object source, EventArgs args);

        public event SendOut MudkipSent;

        bool fainted = false;
        string attack_name = "Growl";
        int health = 30;

        protected void OnSentOut()
        {
            if (MudkipSent != null)
            {
                MudkipSent(this, EventArgs.Empty);
            }
        }

        public void Battle()
        {
            Console.WriteLine($"Mudkip is getting ready to battle!");
            Thread.Sleep(1000);
            OnSentOut();

        }

        public string Attack {
            get
            {
                return attack_name;
            }
            set
            {
                attack_name = value;
            }
        }

        public bool Fainted
        {
            get
            {
                return fainted;
            }
            set { fainted = value; }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
    }

    public class Battle
    {
        public void OnSentOut(object source, EventArgs args)
        {
            Console.WriteLine("All pokemon sent out, the battle is starting!");
        }
    }

    class Activity_4
    {
        public static void Main(string[] args)
        {
            var mudkip = new Mudkip { Attack = "Water Gun" };
            var battle = new Battle();
            mudkip.MudkipSent += battle.OnSentOut;
            mudkip.Battle();
            Console.ReadKey();
        }
    }
}