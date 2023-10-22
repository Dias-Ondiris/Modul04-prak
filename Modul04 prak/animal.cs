using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul04_prak
{
    public abstract class Animal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public abstract (string FoodType, int Amount) NeedFood();
        public override string ToString()
        {
            var food = NeedFood();
            return $"{Id} - {Name} ({GetType().Name}): {food.FoodType}, {food.Amount} kg";
        }
    }
    public class Carnivore : Animal
    {
        public override (string FoodType, int Amount) NeedFood()
        {
            return ("Meat", 5); 
        }
    }

    public class Omnivore : Animal
    {
        public override (string FoodType, int Amount) NeedFood()
        {
            return ("Mixed", 3);
        }
    }

    public class Herbivore : Animal
    {
        public override (string FoodType, int Amount) NeedFood()
        {
            return ("Plants", 4);
        }
    }
}
