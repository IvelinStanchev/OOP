using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class EngineShooting : Engine//Exercise 4
    {
        public EngineShooting(IRenderer renderer, IUserInterface ui, int refreshTime)
            : base(renderer, ui, refreshTime)
        {
        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
