using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Creates Event object with 1, and Calgary as properties
            Event e = new Event(1, "Calgary");

            //Creates file path and serializes Event object to JSON
            string path = "event.json";
            string encoded = JsonSerializer.Serialize(e);

            //Writes the serialized string to file
            File.WriteAllText(path, encoded);

            //Reads the JSON file and creates new Event object from it
            string contents = File.ReadAllText(path);
            Event decoded = JsonSerializer.Deserialize<Event>(contents);

            //Prints the properties of the newly created object from JSON file
            Console.WriteLine(decoded.EventNumber);
            Console.WriteLine(decoded.Location);

            ReadFromFile();
        }

        //Reads from file method, where it creates a new file writes a word then reads first, middle and last char
        /*
         * FOR SOME REASON I HAD TO CLOSE AND REOPEN FILE OR IT WOULD NOT SEEK PROPERLY, I WILL SHOW YOU ON NEXT CLASS TIME, I WROTE EXACTLY THE SAME CODE AS YOU AND IT WOULDN'T WORK
         *
         */
        static void ReadFromFile()
        {
            string path = "name.txt";

            // Writes Hackathon to new file named "name.txt"
            StreamWriter stream = File.CreateText(path);
            stream.Write("Heckathon");
            stream.Close();
            Console.WriteLine("Hackathon written in file");

            //Opens file to read, seeks to first position and prints out first char of word
            StreamReader streamReader = File.OpenText(path);
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            int charNumb = streamReader.Read();
            char first = (char)charNumb;
            Console.WriteLine($"First: {first}");
            streamReader.Close();

            //Opens file to read, seeks to middle position and prints out middle char of word
            streamReader = File.OpenText(path);
            int middlePosition = (int)streamReader.BaseStream.Length / 2;
            streamReader.BaseStream.Seek(middlePosition, SeekOrigin.Begin);
            charNumb = streamReader.Read();
            char middle = (char)charNumb;
            Console.WriteLine($"Middle: {middle}");
            streamReader.Close();

            //Opens file to read, seeks to last position and prints out last char of word
            streamReader = File.OpenText(path);
            int lastPosition = (int)streamReader.BaseStream.Length - 1;
            streamReader.BaseStream.Seek(lastPosition, SeekOrigin.Begin);
            charNumb = streamReader.Read();
            char last = (char)charNumb;
            Console.WriteLine($"Last: {last}");
            streamReader.Close();
        }
    }
}
