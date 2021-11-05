using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LabWork2
{
    public class Seaport : IEqualityComparer<Dock>
    {
        public string Address { get; set; }
        public string Name { get; set; }

        private const ushort DockEquipment = 5;
        private const ushort DockWorkers = 15;

        private int _workersNumber;

        public double EquipmentPrice { get; set; }

        public int ShipServiceTime { get; set; }
        public int ShipServicePrice { get; set; }

        public readonly List<Dock> Docks;
        private int _functioningDocks;

        public Seaport(string address, string name, int serviceTime, int servicePrice, int equipmentPrice)
        {
            Address = address;
            Name = name;
            ShipServiceTime = serviceTime;
            ShipServicePrice = servicePrice;
            EquipmentPrice = equipmentPrice;
            Docks = new List<Dock>();
            Docks.Add(new Dock());
        }

        public Seaport(Seaport obj)
        {
            Address = obj.Address;
            Name = obj.Name;
            ShipServiceTime = obj.ShipServiceTime;
            ShipServicePrice = obj.ShipServicePrice;

            _workersNumber = obj.GetWorkers();
            Docks = new List<Dock>();
            foreach (var dock in obj.Docks)
            {
                Docks.Add(new Dock(dock));
            }

            _functioningDocks = obj.GetFunctioningDocks();
        }


        public double CalcIncome(int ships) => ShipServicePrice * ships;

        public static Seaport operator ++(Seaport seaport)
        {
            seaport.Docks.Add(new Dock());
            seaport.UpdateDocksState();
            return seaport;
        }

        public static Seaport operator --(Seaport seaport)
        {
            if (seaport.Docks.Count == 0) return seaport;

            seaport.Docks.RemoveAt(seaport.Docks.Count - 1);
            seaport.UpdateDocksState();
            return seaport;
        }


        private void UpdateDocksState()
        {
            int count = _workersNumber / DockWorkers > Docks.Count ? Docks.Count : _workersNumber / DockWorkers;
            for (int i = 0; i < count; i++) Docks[i].State = DockState.Functioning;
            for (int i = count; i < Docks.Count; i++) Docks[i].State = DockState.WorkersNeeded;
            _functioningDocks = count;
        }

        public void HireWorkers(ushort workers)
        {
            _workersNumber += workers;
            UpdateDocksState();
        }

        public void FireWorker(ushort workers)
        {
            _workersNumber -= workers;
            if (_workersNumber < 0) _workersNumber = 0;
            UpdateDocksState();
        }

        public static bool operator >=(Seaport seaport1, Seaport seaport2) =>
            seaport1._functioningDocks >= seaport2._functioningDocks;

        public static bool operator <=(Seaport seaport1, Seaport seaport2) =>
            seaport1._functioningDocks <= seaport2._functioningDocks;

        public static ushort GetDockEquipmentAmount() => DockEquipment;
        public static ushort GetDockWorkers() => DockEquipment;

        public int GetWorkers() => _workersNumber;
        public int GetFunctioningDocks() => _functioningDocks;

        public bool Equals(Dock x, Dock y) => x.GetHashCode() == y.GetHashCode();
        public int GetHashCode([DisallowNull] Dock obj) => obj.GetHashCode();
    }
}