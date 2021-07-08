using System;
using System.Collections.Generic;

namespace 访问者模式
{
    public interface IVisitor
    {
        void VisitConcreteComponentA(ComponentA component);
        void VisitConcreteComponentB(ComponentB component);
    }


   public class FunctionAVisitor:IVisitor
   {
       public void VisitConcreteComponentA(ComponentA component)
       {
           Console.WriteLine(component.ExclusiveMethodOfConcreteComponentA() + "FunctionAVisitor");
       }

       public void VisitConcreteComponentB(ComponentB component)
       {
           Console.WriteLine(component.ExclusiveMethodOfConcreteComponentB() + "FunctionAVisitor");
        }
   }

   public class FunctionBVisitor : IVisitor
   {
       public void VisitConcreteComponentA(ComponentA component)
       {
           Console.WriteLine(component.ExclusiveMethodOfConcreteComponentA() + "FunctionBVisitor");
        }

       public void VisitConcreteComponentB(ComponentB component)
       {
           Console.WriteLine(component.ExclusiveMethodOfConcreteComponentB() + "FunctionBVisitor");
        }
   }

    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }

    public class   ComponentA:  IComponent
    {
       public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentA(this);
        }

       public string ExclusiveMethodOfConcreteComponentA()
       {
           return "A";
       }
    }

    public class ComponentB : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentB(this);
        }

        public string ExclusiveMethodOfConcreteComponentB()
        {
            return "B";
        }
    }

    public class Client
    {

        public static void Excute(List<IComponent> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
        public static void Main(string[] args)
        {
            var functionAVisitor = new FunctionAVisitor();
            var functionBVisitor = new FunctionBVisitor();

            var components = new List<IComponent>
            {
                new ComponentA(),
                new ComponentB()
            };

            Excute(components, functionAVisitor);
            Excute(components, functionBVisitor);
        }
    }
}
