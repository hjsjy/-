using System;

namespace 责任链模式
{

    public class PurchaseRequest
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public PurchaseRequest(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }

    public abstract class Approver
    {
        public string Name { get; set; }

        public Approver NextApprovder { get; set; }

        public Approver(string name)
        {
            Name = name;
        }

        public abstract void ProcessRequest(PurchaseRequest purchaseRequest);
    }

    public class Manager : Approver
    {
        public Manager(string name) : base(name)
        {
        }

        public override void ProcessRequest(PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest.Amount <= 10000)
            {
                Console.WriteLine("Manager " + Name +" : approve !");
            }
            else
            {
                NextApprovder?.ProcessRequest(purchaseRequest);
            }
        }
    }
    public class SeniorManager : Approver
    {
        public SeniorManager(string name) : base(name)
        {
        }

        public override void ProcessRequest(PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest.Amount > 10000 && purchaseRequest.Amount <= 100000)
            {
                Console.WriteLine("SeniorManager " + Name + " : approve !");
            }
            else
            {
                NextApprovder?.ProcessRequest(purchaseRequest);
            }
        }
    }
    public class Meeting : Approver
    {
        public Meeting(string name) : base(name)
        {
        }

        public override void ProcessRequest(PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest.Amount > 100000)
            {
                Console.WriteLine("Meeting " + Name + " : approve !");
            }
        }
    }

    public class Client
    {
        public static void Main(string[] args)
        {
            PurchaseRequest requestTelphone = new PurchaseRequest("Telphone", 4000.0);
            PurchaseRequest requestSoftware = new PurchaseRequest("Visual Studio", 12000.0);
            PurchaseRequest requestcar = new PurchaseRequest("car", 120000.0);

            var manager = new Manager("narojay");
            var seniorManager = new SeniorManager("narojay1");
            var meeting = new Meeting("narojay2");
            manager.NextApprovder = seniorManager;
            seniorManager.NextApprovder = meeting;

            manager.ProcessRequest(requestTelphone);
            manager.ProcessRequest(requestSoftware);
            manager.ProcessRequest(requestcar);
        }
    }
}
