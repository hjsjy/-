using System;

namespace 原型模式
{
    public class Client
    {
        public static void Main(string[] args)
        {
            var concretePrototype = new ConcretePrototype(Guid.NewGuid().ToString());

            var prototype = concretePrototype.Clone() as ConcretePrototype;
            Console.WriteLine(prototype?.Id);

            var prototype1 = concretePrototype.Clone() as ConcretePrototype;
            Console.WriteLine(prototype1?.Id);
        }

    }
    public abstract class NarutoPrototype
    {
        public string Id { get; set; }

        public NarutoPrototype(string id)
        {
            this.Id = id;
        }
        public abstract NarutoPrototype Clone();
    }

    public class ConcretePrototype : NarutoPrototype
    {
        public ConcretePrototype(string id) : base(id)
        {
        }

        public override NarutoPrototype Clone()
        {
            //调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return (NarutoPrototype)MemberwiseClone();
        }
    }
}
