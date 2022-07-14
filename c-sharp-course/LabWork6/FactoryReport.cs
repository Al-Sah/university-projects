using System;

namespace LabWork6
{
    [Serializable]
    public class FactoryReport
    {
        public FactoryStamp StartStamp { get; set; }
        public FactoryStamp EndStamp { get; set; }

        public string State { get; set; }
    }
}