namespace Square.Repository
{
    public class FigureCollections
    {
        private List<double> wallSqM = new();
        private List<double> windowSqM = new();
        public void AddWallSqM(double value)
        {
            wallSqM.Add(value);
        }
        public void AddWindowSqM(double value)
        {
            windowSqM.Add(value);
        }

        public double GetWallSqM() => Math.Round(wallSqM.Sum(), 2);
        public double GetWindowSqM() => Math.Round(windowSqM.Sum(), 2);

        public double GetWallSubtractWindowSqM()
        {
            if (GetWallSqM() - GetWindowSqM() > 0)
            {
                return Math.Round(GetWallSqM() - GetWindowSqM(), 2);
            }
            return 0;
        }
    }
}
