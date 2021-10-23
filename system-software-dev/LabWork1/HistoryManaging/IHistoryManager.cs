namespace LabWork1.HistoryManaging
{
    public interface IHistoryManager
    {
        void Clear();
        void Print();

        void AddLine(string log);
    }
}