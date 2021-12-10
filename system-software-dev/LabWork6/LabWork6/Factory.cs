using System;
using System.Threading;

namespace LabWork6
{
    public class Factory : IDisposable
    {
        public int Departments { get; }
        public int Products { get; private set; }
        public int RawMaterial { get; private set; }
        public int Money { get; set; }
        public int FreeStorageSpace { get; private set; } // in percentage 
        public State CurrentState { get; set; } // TODO generating report

        public bool Runnable { get; set; }

        public event Action PropertiesUpdated;

        private const int MaterialPrice = 5;
        private const int SailingPrice = 20;
        private const int CreationPrice = 5;
        private const int MaterialSpace = 5; // Percentage in storage

        public EventWaitHandle Event { get; }
        private readonly Thread _worker;

        private const int BuyingTime = 1;
        private const int CreatingTime = 1;
        private const int SailingTime = 2;


        public Factory()
        {
            Runnable = true;
            CurrentState = State.Buying;
            Departments = new Random().Next(10) * 5;
            FreeStorageSpace = 100;
            Event = new ManualResetEvent(false);
            _worker = new Thread(Run);
            _worker.Start();
        }

        private void Run()
        {
            while (Runnable)
            {
                Event.WaitOne();
                switch (CurrentState)
                {
                    case State.Buying:
                    {
                        BuyMaterial();
                        Thread.Sleep(BuyingTime * 1000);
                        break;
                    }
                    case State.Creating:
                    {
                        CreateProduct();
                        Thread.Sleep(CreatingTime * 1000);
                        break;
                    }
                    case State.Sailing:
                    {
                        SaleProduct();
                        Thread.Sleep(SailingTime * 1000);
                        break;
                    }
                }

                PropertiesUpdated?.Invoke();
            }
        }


        private void BuyMaterial()
        {
            if (FreeStorageSpace == 0 || Money <= 0)
            {
                return;
            }

            Money -= MaterialPrice;
            RawMaterial++;
            FreeStorageSpace -= MaterialSpace;
        }

        private void CreateProduct()
        {
            if (RawMaterial == 0)
            {
                return;
            }

            Money -= CreationPrice;
            FreeStorageSpace += MaterialSpace;
            RawMaterial--;
            Products++;
        }

        private void SaleProduct()
        {
            if (Products == 0)
            {
                return;
            }

            Money += SailingPrice;
            Products--;
        }

        public void Dispose() => _worker.Join();
    }

    public enum State
    {
        Buying,
        Sailing,
        Creating
    }
}