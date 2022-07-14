namespace LabWork2
{
    public static class SeaportExtension
    {
        public static int CalcServiceTime(this Seaport seaport, int ships) => seaport.ShipServiceTime * ships;
    }
}