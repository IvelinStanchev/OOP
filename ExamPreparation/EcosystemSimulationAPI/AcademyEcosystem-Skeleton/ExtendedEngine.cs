using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class ExtendedEngine : Engine
    {
        protected override void ExecuteBirthCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "wolf":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        Wolf newwolf = new Wolf(name, position);
                        this.AddOrganism(newwolf);
                        break;
                    }
                case "lion":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        Lion newLion = new Lion(name, position);
                        this.AddOrganism(newLion);
                        break;
                    }
                case "boar":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        Boar newBoar = new Boar(name, position);
                        this.AddOrganism(newBoar);
                        break;
                    }
                case "zombie":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        Zombie newZombie = new Zombie(name, position);
                        this.AddOrganism(newZombie);
                        break;
                    }
                case "grass":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        Grass newGrass = new Grass(position);
                        this.AddOrganism(newGrass);
                        break;
                    }

                default:
                    base.ExecuteBirthCommand(commandWords);
                    break;
            }
        }
    }
}
