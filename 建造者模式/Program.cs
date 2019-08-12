using System;
using System.Collections.Generic;

namespace 建造者模式
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director dieDirector = new Director();
            var concreateBuilder1 = new ConcreateBuilder1();
            var concreateBuilder2 = new ConcreateBuilder2();

            dieDirector.Construct(concreateBuilder1);
            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = concreateBuilder1.GetComputer();
            computer1.Show();
            // 老板叫员工去组装第二台电脑
            dieDirector.Construct(concreateBuilder2);
            Computer computer2 = concreateBuilder2.GetComputer();
            computer2.Show();

            Console.Read();
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartCpu();
            builder.BuildPartMainBoard();
        }
    }

    public abstract class Builder
    {
        public abstract void BuildPartCpu();
        public abstract void BuildPartMainBoard();
        public abstract Computer GetComputer();
    }

    public class Computer
    {

        private IList<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("电脑开始组装....");
            foreach (var part in parts)
            {
                Console.WriteLine($"部件{part}已经装好了");
            }

            Console.WriteLine("电脑组装好了");
        }

    }
    public class ConcreateBuilder1 : Builder
    {
        Computer pc = new Computer();
        public override void BuildPartCpu()
        {
            pc.Add("Cpu1");
        }

        public override void BuildPartMainBoard()
        {
            pc.Add("MainBoard1");
        }

        public override Computer GetComputer()
        {
            return pc;
        }
    }
    public class ConcreateBuilder2 : Builder
    {
        Computer pc = new Computer();
        public override void BuildPartCpu()
        {
            pc.Add("Cpu2");
        }

        public override void BuildPartMainBoard()
        {
            pc.Add("MainBoard2");
        }

        public override Computer GetComputer()
        {
            return pc;
        }
    }
}
