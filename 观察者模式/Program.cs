using System;
using System.Collections.Generic;

namespace 观察者模式
{

    public abstract class Subscription
    {
        private  List<IObserver> Observers = new List<IObserver>();
        public string Name { get; set; }

        public double Duration { get; set; }

        public Subscription(string name, double duration)
        {
            Name = name;
            Duration = duration;
        }

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Update()
        {
            foreach (var observer in Observers)
            {
                observer.GiveYouMoney(this);
            }
        }
    }

    public class NarojaySubscription : Subscription
    {
        public NarojaySubscription(string name, double duration) : base(name, duration)
        {
        }
    }

    public interface IObserver
    {


        public void GiveYouMoney(Subscription subscription);
    }

    public class Subscriber : IObserver
    {
        public string SubscriberName { get; set; }

        public Subscriber(string name)
        {
            SubscriberName = name;
        }
        public void GiveYouMoney(Subscription subscription)
        {
            Console.WriteLine(subscription.Duration + subscription.Name + SubscriberName);
        }
    }

    public class Client
    {
  

        public static void Main(string[] args)
        {
            Subscription subscription1 = new NarojaySubscription("narojayhome", 2);
            Subscription subscription2 = new NarojaySubscription("narojayhome", 2);
            subscription2.AddObserver(new Subscriber("narojay1"));
            subscription2.AddObserver(new Subscriber("narojay2"));
            subscription2.Update();
        }
    }
}
