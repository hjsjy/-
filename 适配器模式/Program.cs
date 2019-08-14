using System;
using System.Text;

namespace 适配器模式
{
    /// <summary>
    /// 可以使用的接口
    /// </summary>
    public interface Target
    {
        void GetTemperature();

        void GetPressure();

        void GetHumidity();

        void GetUltraviolet();
    }

    public class Adaptee
    {
        public void 得到温度()
        {
            Console.WriteLine("得到了温度");
        }

        public void 得到气压()
        {
            Console.WriteLine("得到了气压");
        }

        public void 得到湿度()
        {
            Console.WriteLine("得到了湿度");
        }

        public void 得到紫外线()
        {
            Console.WriteLine("得到了紫外线");
        }
    }

    public class Adapter : Adaptee, Target
    {
        public void GetTemperature()
        {
            得到温度();
        }

        public void GetPressure()
        {
            得到气压();
        }

        public void GetHumidity()
        {
            得到湿度();
        }

        public void GetUltraviolet()
        {
            得到紫外线();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var adapter = new Adapter();
            adapter.GetTemperature();
            adapter.GetHumidity();
            adapter.GetPressure();
            adapter.GetUltraviolet();
        }
    }
}