using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string regex = @"^\![A-Z][a-z]{2,}\!\:\[[A-Za-z]{8,}\]$";

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, regex);

                if (match.Success)
                {
                    var splitted = input.Split(":");
                    string command = splitted[0].Trim('!');

                    
                    Console.Write(command + ": ");

                    foreach (char ch in splitted[1].Trim(new char[] { '[', ']' }))
                    {
                        Console.Write((int)ch + " ");
                    }
                    Console.WriteLine(); 
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}