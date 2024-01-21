using Square.IO.Interfaces;

namespace Square.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj) => Console.WriteLine(obj);
    }
}
