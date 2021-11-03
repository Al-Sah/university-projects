namespace LabWork2
{
    class Dock
    {
        public DockState State { get; set; }

        public Dock()
        {
            State = DockState.WorkersNeeded;
        }

        public Dock(Dock d)
        {
            State = d.State;
        }
    }
}