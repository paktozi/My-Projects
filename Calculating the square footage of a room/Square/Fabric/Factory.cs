using Square.Fabric.Contract;
using Square.Models;
using Square.Models.Interfaces;
using Square.Utilities.Messages;

namespace Square.Fabric
{
    public class Factory : IFactory
    {
        public IFigure CreateFigure(string[] data)
        {
            string type = data[0];
            double height = double.Parse(data[1]);
            double width = double.Parse(data[2]);

            switch (type)
            {
                case "wall": return new Wall(height, width);
                case "window":
                    if (data.Length == 4)  // if data.length == 4 ,window have a reveal area(data[3]).
                    {
                        return new Window(height, width, double.Parse(data[3]));
                    }
                    return new Window(height, width);
                default: throw new ArgumentException(Messages.invalidFigure);
            }
        }
    }
}
