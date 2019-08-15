using System;
using System.Collections.Generic;

namespace 组合模式

{/// <summary>
 /// 安全组合模式 不会抛出异常
/// 组合模式允许你将对象组合成树形结构来表现”部分-整体“的层次结构，使得客户以一致的方式处理单个对象以及对象的组合
/// </summary>
    public abstract class Graphics
    {
        public string Name { get; set; }

        protected Graphics(string name)
        {
            Name = name;
        }

        public abstract void Draw();

     
    }


    public class line : Graphics
    {
        public line(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine($"画一条{Name}线。");
        }
    }

    public class Circle : Graphics
    {
      
        public Circle(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine($"画一个{Name}圆形。");
        }
    }
    
    public class ComplexGraphics : Graphics
    {
        private readonly List<Graphics> _complexList = new List<Graphics>();
        public ComplexGraphics(string name) : base(name)
        {
           
        }

        public override void Draw()
        {
            foreach (var g in _complexList)
            {
                g.Draw();
            }

        }

        public  void Add(Graphics g)
        {
            _complexList.Add(g);
        }

        public  void Remove(Graphics g)
        {
            _complexList.Remove(g);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var complexGraphics = new ComplexGraphics("复杂图形");
            var line1 = new line("线段1");
            var line2 = new line("线段2");
            var circle1 = new Circle("圆形1");
            complexGraphics.Add(line1);
            complexGraphics.Add(line2);
            complexGraphics.Add(circle1);
            complexGraphics.Draw();
        }
    }
}
