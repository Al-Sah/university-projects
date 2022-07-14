namespace LabWork2
{
    public class Dock
    {
        public DockState State { get; set; }

        public Dock() => State = DockState.WorkersNeeded;
        public Dock(Dock d) => State = d.State;
    }
}