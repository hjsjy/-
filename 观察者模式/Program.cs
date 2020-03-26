using System;

namespace 观察者模式
{

    public abstract class Subscription
    {
        public delegate void NotifyHandler(object sender);

        public NotifyHandler notify;
        public string Name { get; set; }

        public double Duration { get; set; }

        public Subscription(string name, double duration)
        {
            Name = name;
            Duration = duration;
        }

        public void AddObserver(NotifyHandler ob)
        {
            notify += ob;
        }

        public void RemoveObserver(NotifyHandler ob)
        {
            notify -= ob;
        }

        public void Update()
        {
            notify?.Invoke(this);
        }
    }

    public class NarojaySubscription : Subscription
    {
        public NarojaySubscription(string name, double duration) : base(name, duration)
        {
        }
    }

    public class Subscriber
    {
        public string SubscriberName { get; set; }

        public Subscriber(string name)
        {
            SubscriberName = name;
        }

        public void GiveYouMoney(object sender)
        {
            var subscription = sender as Subscription;
            if (subscription != null)
            {

                Console.WriteLine(subscription.Duration + subscription.Name + SubscriberName);
            }

        }


    }

    public class Client
    {


        public static void Main(string[] args)
        {
            Subscription subscription2 = new NarojaySubscription("narojayhome", 2);
            var subscriber1 = new Subscriber("test1");
            var subscriber2 = new Subscriber("test2");
            subscription2.AddObserver(subscriber1.GiveYouMoney);
            subscription2.AddObserver(subscriber2.GiveYouMoney);
            subscription2.Update();
        }
    }
}
