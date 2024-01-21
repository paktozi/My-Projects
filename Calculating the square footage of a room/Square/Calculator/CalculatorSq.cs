using Square.Models.Interfaces;

namespace Square.Calculator
{
    public static class CalculatorSq
    {
        public static double[] Calculate(IFigure figure)
        {
            double[] figData = new double[2];

            if (figure.GetType().Name == "Wall")
            {
                figData[0] = figure.Height * figure.Width;    // Calculate wall m².
            }
            else if (figure.GetType().Name == "Window")
            {
                if (figure.Reveal > 0)                                                              //if reveal exist.
                {
                    figData[0] = (figure.Reveal * figure.Height) * 2 + figure.Reveal * figure.Width; // Calculate window reveal m².
                    figData[1] = figure.Height * figure.Width;                                       // Calculate window m².
                }
                else
                {
                    figData[1] = figure.Height * figure.Width;      // Calculate window m² without reveal.
                }
            }
            return figData;
        }
    }
}
