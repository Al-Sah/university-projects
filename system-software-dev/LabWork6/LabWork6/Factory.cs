using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace LabWork6
{
    public class Factory : IDisposable
    {
        public int Departments { get; }
        public int Products { get; private set; }
        public int RawMaterial { get; private set; }
        public int Money { get; set; }
        public int FreeStorageSpace { get; private set; } // in percentage 


        private FactoryStamp _stamp;
        private State _state;

        public State CurrentState
        {
            get => _state;
            set
            {
                if (value == _state)
                {
                    return;
                }

                var newStamp = new FactoryStamp(this);
                GenerateReport(_state, _stamp, newStamp);
                _state = value;
                _stamp = newStamp;
            }
        }

        private static void GenerateReport(State state, FactoryStamp begin, FactoryStamp end)
        {
            var format = new XmlSerializer(typeof(FactoryReport));
            var filename = Directory.GetCurrentDirectory() + "/" + state + "Report";
            var tmp = filename + ".alxrp";
            var number = 1;
            while (File.Exists(tmp))
            {
                tmp = filename + number + ".alxrp";
                number++;
            }

            filename = tmp;
            using (var file = new FileStream(filename, FileMode.Create))
            {
                format.Serialize(file, new FactoryReport
                {
                    StartStamp = begin,
                    EndStamp = end,
                    State = state.ToString()
                });
            }
        }

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
            _worker = new Thread(Run) {IsBackground = true};
            _worker.Start();
        }

        private void Run()
        {
            Thread.Sleep(500);
            _stamp = new FactoryStamp(this);
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

    [Serializable]
    public struct FactoryStamp
    {
        public int Products;
        public int RawMaterial;
        public int Money;
        public int FreeStorageSpace;

        public FactoryStamp(Factory factory)
        {
            Products = factory.Products;
            RawMaterial = factory.RawMaterial;
            Money = factory.Money;
            FreeStorageSpace = factory.FreeStorageSpace;
        }
    }
}