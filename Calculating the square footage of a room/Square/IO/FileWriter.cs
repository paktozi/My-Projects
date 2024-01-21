using Square.IO.Interfaces;

namespace Square.IO
{
    public class FileWriter : IFileWriter
    {
        public void Filewrite(object obj)
        {
            string path = "../../../Results.txt";
            using StreamWriter sw = new(path, true);
            sw.WriteLine(obj);
        }
    }
}
