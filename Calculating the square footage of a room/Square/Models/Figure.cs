using Square.Models.Interfaces;
using Square.Utilities.Messages;

namespace Square.Models
{
    public abstract class Figure : IFigure
    {
        private double height;
        private double width;
        private double reveal;

        public Figure(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public Figure(double height, double width, double reveal)
        {
            Height = height;
            Width = width;
            Reveal = reveal;
        }

        public double Reveal
        {
            get => reveal;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Messages.revealIsNegative);
                }
                reveal = value;
            }
        }

        public double Height
        {
            get => height;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.heightNegative);
                }
                height = value;
            }
        }
        public double Width
        {
            get => width;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.widthNegative);
                }
                width = value;
                width = value;
            }
        }
        public override string ToString() => $"Height:{Height}m  Width:{Width}m";
    }
}
