using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieSize = 0;
        private const int MeatUnits = 10;

        public Zombie(string name, Point position)
            : base(name, position, ZombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return MeatUnits;
        }
    }
}
