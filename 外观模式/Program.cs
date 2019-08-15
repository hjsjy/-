using System;

namespace 外观模式
{
    /// <summary>
    /// 由外观类去保存各个子系统的引用，从而使客户端和子系统解耦，客户端只需要依赖 外观类就行了。
    /// </summary>
    public class RegisterClient
    {
        private readonly CourseServer _courseServer;

        private readonly NotifyServer _notifyServer;

        public RegisterClient()
        {
            _courseServer = new CourseServer();
            _notifyServer = new NotifyServer();
        }

        public bool Register(string courseName, string studentName)
        {
            return _courseServer.CheckCourse(courseName) && _notifyServer.NotifyStudent(studentName);
        }
    }

    public class CourseServer
    {
        public bool CheckCourse(string courseName)
        {
            Console.WriteLine($"检查课程{courseName}是否满了");
            return true;
        }
            
    }

    public class NotifyServer
    {
        public bool NotifyStudent(string studentName)
        {
            Console.WriteLine($"正在通知{studentName} 学生");
            return true;
        }
    }
    public  class Program
    {
        private static readonly RegisterClient Client = new RegisterClient();
        static void Main(string[] args)
        {
            if (Client.Register("设计模式","narojay"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }
          
        }
    }
}
