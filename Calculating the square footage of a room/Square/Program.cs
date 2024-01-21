using Square.Core;
using Square.Core.Interface;
using Square.Fabric;
using Square.Fabric.Contract;
using Square.IO;
using Square.IO.Interfaces;
Console.OutputEncoding = System.Text.Encoding.UTF8;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IFileWriter fileWriter = new FileWriter();
IFactory factory = new Factory();
IEngine engine = new Engine(reader, writer, fileWriter, factory);

engine.Run();