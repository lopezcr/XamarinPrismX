using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinPrismX.ViewModels
{
    public class CollectionViewGroupingViewModel : BindableBase
    {
        public List<AnimalGroup> Animals { get; private set; } = new List<AnimalGroup>();

        public CollectionViewGroupingViewModel()
        {
            load();
        }


        public void load()
        {
        Animals.Add(new AnimalGroup("Bears", new List<Animal>
            {
                new Animal
                {
                    Name = "American Black Bear",
                    Location = "North America",
                    Details = "Details about the bear go here.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzbär.jpg"
                },
                new Animal
                {
                    Name = "Asian Black Bear",
                    Location = "Asia",
                    Details = "Details about the bear go here.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG/180px-Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG"
                }
        }));

        Animals.Add(new AnimalGroup("Monkeys", new List<Animal>
            {
                new Animal
                {
                    Name = "Baboon",
                    Location = "Africa & Asia",
                    Details = "Details about the monkey go here.",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                },
                new Animal
                {
                    Name = "Capuchin Monkey",
                    Location = "Central & South America",
                    Details = "Details about the monkey go here.",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
                },
                new Animal
                {
                    Name = "Blue Monkey",
                    Location = "Central and East Africa",
                    Details = "Details about the monkey go here.",
                    ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
                }
                 }));
        }
    }



    public class Animal
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
    }

    public class AnimalGroup : List<Animal>
    {
        //public string Name { get; private set; }
        public string Name { get; set; }

        public AnimalGroup(string name, List<Animal> animals) : base(animals)
        {
            Name = name;
        }
    }

}
