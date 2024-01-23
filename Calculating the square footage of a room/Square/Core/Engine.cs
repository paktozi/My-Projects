using Square.Calculator;
using Square.Core.Interface;
using Square.Fabric.Contract;
using Square.IO.Interfaces;
using Square.Models.Interfaces;
using Square.Repository;
using Square.Utilities.Messages;

namespace Square.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFileWriter fileWriter;
        private readonly IFactory factory;
        FigureCollections repository;
        double[] calculatedSquareMt = new double[2];

        public Engine(IReader reader, IWriter writer, IFileWriter fileWriter, IFactory factory)
        {
            this.reader = reader;
            this.writer = writer;
            this.fileWriter = fileWriter;
            this.factory = factory;
            repository = new FigureCollections();
        }

        public void Run()
        {
            string data;                                                                                       // Print Start message.           
            Messages.IntroInfo();

            while ((data = Console.ReadLine()) != "end")
            {
                string[] input = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);                                     // Input data .
                IFigure figure = null;

                try
                {
                    if (input[0] == "wall")
                    {
                        figure = factory.CreateFigure(input);                                                                    // Go to factory and create figure by type.
                    }
                    else if (input[0] == "window")
                    {
                        figure = factory.CreateFigure(input);                                                                  // Go to factory and create figure by type.                  

                    }
                    else if (input[0] == "total")
                    {
                        PrintTotalSquare();                                         //Print final clear m² to paint.
                        break;
                    }
                    if (figure == null)
                    {
                        writer.WriteLine(Messages.invalidFigure);                                                                       //Print message is input is not correct.   
                        continue;
                    }

                    calculatedSquareMt = CalculatorSq.Calculate(figure);                                                            //   return square meter as array  ar[0]= m² of wall/reveal; ar[1]=m² of window.
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    if (calculatedSquareMt[0] > 0)                                                                                // if value is>0 add to Total-Walls m² List;
                    {
                        repository.AddWallSqM(calculatedSquareMt[0]);
                        if (calculatedSquareMt[1] > 0)
                        {
                            writer.WriteLine($"Window reveal: {calculatedSquareMt[0]:f2}m²");
                            fileWriter.Filewrite($"Window reveal: {calculatedSquareMt[0]:f2}m²");                            //  write to text file.
                        }
                        else
                        {
                            writer.WriteLine($"Wall: {calculatedSquareMt[0]:f2}m²");
                            fileWriter.Filewrite($"Wall: {calculatedSquareMt[0]:f2}m²");
                        }
                    }
                    if (calculatedSquareMt[1] > 0)                                                                             // if value is>0 add to Total-Windows m² List;
                    {
                        repository.AddWindowSqM(calculatedSquareMt[1]);
                        writer.WriteLine($"Window: {calculatedSquareMt[1]:f2}m²");
                        fileWriter.Filewrite($"Window: {calculatedSquareMt[1]:f2}m²");
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                    Messages.IntroInfo();
                    fileWriter.Filewrite("---------------------");
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private void PrintTotalSquare()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            writer.WriteLine($"Total Walls area {repository.GetWallSqM()}m²");                                          //Print Walls and reveal m²
            fileWriter.Filewrite($"Total Walls area {repository.GetWallSqM()}m²");
            Console.ForegroundColor = ConsoleColor.Green;

            writer.WriteLine($"Total Windows area  {repository.GetWindowSqM()}m²");                                     // Print Windows m²
            fileWriter.Filewrite($"Total Windows area  {repository.GetWindowSqM()}m²");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            writer.WriteLine($"Final Walls clear area to paint {repository.GetWallSubtractWindowSqM()}m²");
            fileWriter.Filewrite($"Final Walls clear area to paint {repository.GetWallSubtractWindowSqM()}m²");
            fileWriter.Filewrite("######################################");
            Console.ResetColor();
        }
    }
}
