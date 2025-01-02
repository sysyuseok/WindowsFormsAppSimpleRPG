using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Game
{
    internal class Monster
    {
        // 1024byte
        protected int hp;
        protected int power;
        public const int target_id = 111;

        public Monster(int hp, int power)
        {
            this.hp = hp;
            this.power = power;
        }

        public virtual string Talk() => "BABYMONSTER\r\n";
        public int Attack()
        {
            return this.power;
        }

        public void Damaged(int damage)
        {
            this.hp -= damage;

            if (this.hp < 0) { this.hp = 0; }
        }
    }

    internal class Orc : Monster
    {
        string name;

        public Orc(int hp, int power) : base(hp, power) { }

        public override string Talk() => "Orc Oak\r\n";
        public int Bash() { return this.power + 5; }

    }

    internal class Slime : Monster
    {
        string name;

        public Slime(int hp, int power) : base(hp, power) { }

        public override string Talk() => "Slime!\r\n";
        public int Heal() { return this.hp + 5; }

    }
}
