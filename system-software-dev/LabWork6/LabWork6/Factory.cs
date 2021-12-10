using System;
using System.Threading;

namespace LabWork6
{
    public class Factory : IDisposable
    {
        public int Departments { get; }
        public int Products { get; set; }
        public int RawMaterial { get; set; }
        public int Money { get; set; }
        public int FreeStorageSpace { get; set; } // in percentage 

        public State CurrentState { get; set; }

        public bool Runnable { get; set; }

        public event Action ProductSailed;
        public event Action MaterialBought;
        public event Action ProductCreated;

        private const int MaterialPrice = 5;
        private const int SailingPrice = 20;
        private const int CreationPrice = 5;
        private const int MaterialSpace = 5; // Percentage in storage
        private readonly Thread _worker;

        private const int BuyingTime = 1;
        private const int CreatingTime = 1;
        private const int SailingTime = 2;


        public Factory()
        {
            Runnable = true;
            CurrentState = State.Waiting;
            Departments = new Random().Next(10) * 5;
            FreeStorageSpace = 100;
            _worker = new Thread(Run);
            _worker.Start();
        }

        private void Run()
        {
            while (Runnable)
            {
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
                    case State.Waiting:
                    {
                        Thread.Sleep(1000);
                        break;
                    }
                }
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
            MaterialBought?.Invoke();
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
            ProductCreated?.Invoke();
        }

        private void SaleProduct()
        {
            if (Products == 0)
            {
                return;
            }

            Money += SailingPrice;
            Products--;
            ProductSailed?.Invoke();
        }

        public void Dispose() => _worker.Join();
    }

    public enum State
    {
        Buying,
        Sailing,
        Creating,
        Waiting
    }
}