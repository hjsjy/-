using System;

namespace 策略者模式
{
    /// <summary>
    /// 1178
    /// </summary>
    public interface IStrategy
    {
        void Calculate(int money);
    }

    public class PersonStrategy: IStrategy
    {
        public void Calculate(int money)
        {
            Console.WriteLine(money* 0.1);
        }
    }
    public class ForeignStrategy : IStrategy
    {
        public void Calculate(int money)
        {
            Console.WriteLine(money * 0.5);
        }
    }
    public class EnterpriseStrategy : IStrategy
    {
        public void Calculate(int money)
        {
            Console.WriteLine(money * 0.7);
        }
    }

    public class TaxCalculate
    {
        private readonly IStrategy _strategy;

        public TaxCalculate(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Gettax(int money)
        {
            _strategy.Calculate(money);
        }
    }

    public class Client
    {
        public static void Main(string[] args)
        {
            var taxCalculate1 = new TaxCalculate(new EnterpriseStrategy());
            var taxCalculate2 = new TaxCalculate(new PersonStrategy());
            var taxCalculate3 = new TaxCalculate(new ForeignStrategy());
            taxCalculate1.Gettax(100000);
            taxCalculate2.Gettax(2000);
            taxCalculate3.Gettax(2000);
        }
    }
}
