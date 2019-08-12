using System;
using System.Collections.Generic;
using System.Text;

namespace 工厂方法模式
{
    public abstract class Food
    {
        public abstract void Print();
    }

    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("做一份西红柿炒蛋");
        }
    }
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("做一份土豆肉丝");
        }
    }

    public abstract class Creater
    {
        public abstract Food CreateFoodFactory();
    }

    public class ShreddedPorkWithPotatoesFactory : Creater
    {
        public override Food CreateFoodFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }

    public class TomatoScrambledEggsFactory : Creater
    {
        public override Food CreateFoodFactory()
        {
            return new TomatoScrambledEggs();
        }
    }
}
