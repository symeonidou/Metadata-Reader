using System;
using System.IO;

namespace Lab3
{
    internal abstract class Program
    {
        private static void Main(string[] args)
        {
            var dataCheck = new DataCheck(CheckPath(args));
            InvalidFile(dataCheck.ClassObjectCreator(dataCheck.CheckFile()));
        }
        private static string CheckPath(string[] args)
        {
            string getPath;

            if (args.Length != 0)
            {
                getPath = args[0];
            }
            else
            {
                Console.Write("Enter a valid file path with the extension .png or .bmp: ");
                getPath = Console.ReadLine();
            }

            while (!File.Exists(getPath))
            {
                Console.WriteLine("File not found! \nPlease try again to insert a proper path:");
                getPath = Console.ReadLine();
            }
            return getPath;
        }
        private static void InvalidFile(object filetype)
        {
            if (filetype == null)
            {
                Console.WriteLine("This is not a valid .bmp or .png file!");
                return;
            }
            Console.WriteLine($"\n{filetype}\n");

            if (filetype is not Png p)
            {
                return;
            }

            System.Collections.Generic.IEnumerable<Chunk> chunks = p.GetListOfChunks();
            Console.WriteLine("Chunk data: ");
            foreach (var chunk in chunks)
            {
                Console.WriteLine(chunk);
            }
        }
    }
}
    public class Chunk
{
    private readonly int _sizeOfData;
    private readonly string _type;

    public Chunk(int sizeOfData, string type)
    {
        _sizeOfData = sizeOfData;
        _type = type;
    }
    public override string ToString()
    {
        return $"Chunkname is {_type}, Chunksize is {_sizeOfData} bytes";
    }
}
