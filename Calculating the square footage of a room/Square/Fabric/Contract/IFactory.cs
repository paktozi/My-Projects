using Square.Models.Interfaces;

namespace Square.Fabric.Contract
{
    public interface IFactory
    {
        IFigure CreateFigure(string[] data);
    }
}
