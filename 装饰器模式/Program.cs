using System;

namespace 装饰器模式
{
    public abstract class Phone
    {
        public abstract void Print();
    }

    public class ApplePhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("具体抽象苹果手机");
        }
    }

    public abstract class Decorator : Phone
    {
        private readonly Phone phone;

        protected Decorator(Phone p)
        {
            phone = p;
        }

        public override void Print()
        {
            phone?.Print();
        }
    }

    public class Sticker : Decorator
    {
        public Sticker(Phone p) : base(p)
        {

        }

        public override void Print()
        {
            base.Print();
            AddSticker();
        }

        private void AddSticker()
        {
            Console.WriteLine("现在苹果手机有贴膜了");
        }
    }

    public class Accessories : Decorator
    {
        public Accessories(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            AddAccessories();
        }

        public void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }
    }

    /// <summary>
    /// 装饰者模式来动态地给一个对象添加额外的职责
    /// 在装饰器和具体的功能之间不断的print交互
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new ApplePhone();

 
            Decorator applePhoneWithSticker = new Sticker(phone);

            applePhoneWithSticker.Print();
            Console.WriteLine("----------------------\n");

            Decorator applePhoneWithAccessories = new Accessories(phone);
            applePhoneWithAccessories.Print();
            Console.WriteLine("----------------------\n");

            var sticker = new Sticker(phone);
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
            applePhoneWithAccessoriesAndSticker.Print();
            Console.ReadLine();
        }
    }
}
