using System;

namespace 工厂方法模式
{   
    /// <summary>
    /// 1
    /// </summary>
    public class client
    {
        static void Main(string[] args)
        {
            var shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            var tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();

            var tomatoFactory = tomatoScrambledEggsFactory.CreateFoodFactory();
            tomatoFactory.Print();

            var shreddedFactory = shreddedPorkWithPotatoesFactory.CreateFoodFactory();
            shreddedFactory.Print();
        }
    }
}
