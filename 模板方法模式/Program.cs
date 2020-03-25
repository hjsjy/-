using System;

namespace 模板方法模式
{
    public abstract class Recipe
    {

        public void Cook()
        {
            AddOil();
            AddVegatable();
            AddWater();
        }
        public void AddOil()
        {
            Console.WriteLine("add oil");
        }

        public void AddWater()
        {
            Console.WriteLine("add water");
        }

        public abstract void AddVegatable();
    }


    public class TomatoRecipe : Recipe
    {
        public override void AddVegatable()
        {
            Console.WriteLine("add tomato");
        }
    }
    public class PotatoRecipe : Recipe
    {
        public override void AddVegatable()
        {
            Console.WriteLine("add Potato");
        }
    }

    public class Client
    {
        public static void Main(string[] args)
        {
            Recipe recipe1 = new PotatoRecipe();
            recipe1.Cook();
            Console.WriteLine("====================================");
            Recipe recipe2 = new TomatoRecipe();
            recipe2.Cook();

        }
      


    }
}
