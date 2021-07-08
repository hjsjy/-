using System;

namespace 单例模式
{
    /// <summary>
    /// tes11
    /// </summary>
    public class Singleton
    {

        private static Singleton uniqueInstance;

        public Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Singleton(); ;
            }

            return uniqueInstance;
        }
        static void Main(string[] args)
        {
            var singleton = GetInstance();
            var singleton1 = GetInstance();
        }
    }
}
