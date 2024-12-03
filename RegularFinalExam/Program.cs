using System;
using System.Collections.Generic;
using System.Text;

namespace RegularFinalExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Abracadabra")
            {
                List<string> parts = new List<string>(command.Split(" "));

                string action = parts[0];

                if (action == "Abjuration")
                {
                    spell = spell.ToUpper();

                    Console.WriteLine(spell);
                }
                else if (action == "Necromancy")
                {
                    spell = spell.ToLower();

                    Console.WriteLine(spell);
                }
                else if (action == "Illusion")
                {
                    int index = int.Parse(parts[1]);
                    char letter = char.Parse(parts[2]);

                    if (index >= 0 && index < spell.Length)
                    {
                        StringBuilder sb = new StringBuilder(spell);
                        sb[index] = letter;  // change the letter
                        spell = sb.ToString();

                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                }
                else if (action == "Divination")
                {
                    string firstSubstring = parts[1];
                    string secondSubstring = parts[2];

                    if (spell.Contains(firstSubstring))
                    {
                        spell = spell.Replace(firstSubstring, secondSubstring);

                        Console.WriteLine(spell);
                    }
                }
                else if (action == "Alteration")
                {
                    string substring = parts[1];

                    if (spell.Contains(substring))
                    {
                        spell = spell.Replace(substring, "");

                        Console.WriteLine(spell);
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }

                command = Console.ReadLine();
            }
        }
    }
}
