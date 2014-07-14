using System;

class ExerciseAnimals
{
    static void Main()
    {
        Dog[] dogs = new Dog[] 
        { 
            new Dog("Quey", 5, 'm'),
            new Dog("Ageang", 4, 'm'),
            new Dog("Bykim", 8, 'f'),
        };

        Frog[] frogs = new Frog[] 
        { 
            new Frog("Enon", 2, 'f'),
            new Frog("Lynnage", 1, 'm'),
            new Frog("Serlorpoldraold", 4, 'f'),
        };

        Kitten[] kittens = new Kitten[] 
        { 
            new Kitten("Tiaemi", 1, 'm'),//If you choose 'm' by mistake it will be made 'f'
            new Kitten("Samaim", 5, 'm'),
            new Kitten("Rodkim", 4, 'f'),
        };

        TomCat[] tomCats = new TomCat[] 
        { 
            new TomCat("Tinorm", 3, 'm'),//If you choose 'f' by mistake it will be made 'm'
            new TomCat("Asin", 4, 'm'),
            new TomCat("Rodechi", 1, 'f'),
        };

        dogs[0].ProduceSound();
        frogs[0].ProduceSound();
        kittens[0].ProduceSound();
        tomCats[0].ProduceSound();

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();

        Console.WriteLine("Average age of dogs: {0:F2}", Animal.AverageAge(dogs));
        Console.WriteLine("Average age of frogs: {0:F2}", Animal.AverageAge(frogs));
        Console.WriteLine("Average age of kittens: {0:F2}", Animal.AverageAge(kittens));
        Console.WriteLine("Average age of tomcats: {0:F2}", Animal.AverageAge(tomCats));
    }
}
