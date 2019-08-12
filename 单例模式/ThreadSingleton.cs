using System;
using System.Collections.Generic;
using System.Text;

namespace 单例模式
{
    /// <summary>
    /// 多线程下的单例模式
    /// </summary>
    public class ThreadSingleton
    {
        private static ThreadSingleton _uniqueInstance;

        private static readonly  object _locker = new object();

        private ThreadSingleton()
        {

        }

        public static ThreadSingleton GetInstance()
        {
            if (_uniqueInstance == null)
            {
                lock (_locker)
                {
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new ThreadSingleton();
                    }
                }
            }

            return _uniqueInstance;
        }
    }
}
