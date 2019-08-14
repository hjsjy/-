using System;

namespace 桥接模式
{

    /// <summary>
    /// 桥接模式实现了抽象化与实现化的解耦，使它们相互独立互不影响到对方。
    ///如果遥控器有A种，电视B种 继承实现 需要 A*B个类。
    ///桥接实现 就是A+B个类
    /// </summary>
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void TuneChannel();
    }

    public class XiaoMiTV : TV
    {
        public override void On()
        {
            Console.WriteLine("打开小米电视");
        }

        public override void Off()
        {
            Console.WriteLine("关闭小米电视");
        }

        public override void TuneChannel()
        {
            Console.WriteLine("切换小米电视频道");
        }

        public void VolumeUp()
        {
            Console.WriteLine("小米电视音量增加");
        }

    }

    public class HuaWeiTv : TV
    {
        public override void On()
        {
            Console.WriteLine("打开华为电视");
        }

        public override void Off()
        {
            Console.WriteLine("关闭华为电视");
        }

        public override void TuneChannel()
        {
            Console.WriteLine("切换华为电视频道");
        }
    }

    public class RemoteControl
    {
        public TV Implement { get; set; }

        public virtual void On()
        {
            Implement.On();
        }

        public virtual void Off()
        {
            Implement.Off();
        }

        public virtual void TuneChannel()
        {
            Implement.TuneChannel();
        }
        //增加一个功能
        public virtual void VolumeRemote()
        {
            if (Implement is XiaoMiTV tv)
            {
                tv.VolumeUp();
            }
        }

    }

    public class XiaoMiRemoteControl : RemoteControl
    {
        public override void TuneChannel()
        {
            Console.WriteLine("====================");
            base.TuneChannel();
            Console.WriteLine("=====================");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new XiaoMiRemoteControl();
            remoteControl.Implement = new XiaoMiTV();
            remoteControl.VolumeRemote();
            remoteControl.On();
            remoteControl.TuneChannel();
            remoteControl.Off();



        }
    }
}
