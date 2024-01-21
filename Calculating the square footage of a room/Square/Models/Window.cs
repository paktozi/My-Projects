namespace Square.Models
{
    public class Window : Figure
    {
        public double reveal;

        public Window(double height, double width) : base(height, width)
        {

        }
        public Window(double height, double width, double reveal) : base(height, width, reveal)
        {

        }
        public override string ToString()
        {
            return base.ToString() + (Reveal > 0 ? $" Reveal:{Reveal}m" : "");   //   If reveal is >0,print item,or print empty.
        }
    }
}
