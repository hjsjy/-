using System;

namespace 命令模式
{
    public class Recevier
    {
        public void Run()
        {
            Console.WriteLine("run ");
        }
    }

    public abstract class Command
    {
        protected readonly Recevier _recevier;

        public Command(Recevier recevier)
        {
            _recevier = recevier;
        }

        public abstract void Action();
    }

    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Recevier recevier) : base(recevier)
        {

        }

        public override void Action()
        {
            _recevier.Run();
        }
    }

    public class Invoker
    {
        private readonly Command _command;

        public Invoker(Command command)
        {
            _command = command;
        }

        public void Excute()
        {
            _command.Action();
        }
    }

    public class Client
    {
        public static void Main(string[] args)
        {
            var command = new ConcreteCommand(new Recevier());
            var invoker = new Invoker(command);
            invoker.Excute();
        }
    }
}
