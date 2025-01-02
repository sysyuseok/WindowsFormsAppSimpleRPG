using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Game
{
    internal class PlayerControl
    {
        public PlayerControl() { }
    }

    internal class Character
    {
        // 1024byte
        protected int hp;
        protected int power;
        public const int target_id = 112;

        public Character(int hp, int power)
        {
            this.hp = hp;
            this.power = power;
        }

        public virtual string Talk() => "Who R U\r\n";

        public int Attack()
        {
            return this.power;
        }

        public void Damaged(int damage)
        {
            this.hp -= damage;

            if (this.hp < 0) { this.hp = 0; }
        }
        public string LevelUp(int hp)
        {
            this.hp = hp;
            return "new hp : " + this.hp.ToString()+"\r\n";
        }
        public string LevelUp(int hp,int power)
        {
            this.hp = hp;
            this.power = power;
            return "new hp : "+this.hp.ToString()+" new power : "+this.power.ToString()+"\r\n";
        }
        public string LevelUp()
        {
            return "You didn't put any component!!\r\n";
        }
    }

    internal class Player : Character
    {
        PlayerControl playerControl;

        public Player(int hp, int power) : base(hp, power) { }

        public void ButtonInput() { }
        public override string Talk() => "I'm the main character\r\n";

    }

    internal class NPC : Character
    {
        string name;

        public NPC(int hp, int power) : base(hp, power) { }

        public override string Talk()
        {
            return base.Talk();
        }
    }
}
