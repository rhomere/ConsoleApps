using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps.Isogram
{
    public class IsogramService
    {
        public void Intro()
        {
            Console.WriteLine("An isogram is a word that has no repeating letters, consecutive or nonconsecutive.\nCreate a function that takes a string and returns either true or false depending \non whether or not it's an \"isogram\".\n\n");
        }

        public void Execute()
        {
            Start:
            Console.Write("Enter word: ");
            
            var input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception();

            if (input.Split(' ').Count() > 1)
                throw new Exception();

            var word = String.Concat(input.OrderBy(c => c));

            var check = false;

            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    // Not an Isogram
                    check = true;
                }
            }

            if (check)
                Console.WriteLine($"{input} is not an Isogram!\n");
            else
                Console.WriteLine($"{input} is an Isogram!\n");

            TryAgain:
            Console.WriteLine("Try Again? Y/N");

            var response = Console.ReadLine();
            
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(response))
                throw new Exception();

            if (response.ToUpper() == "Y" || response.ToUpper() == "YES")
                goto Start;
            else if (response.ToUpper() == "N" || response.ToUpper() == "NO")
                goto Exit;
            else
                goto TryAgain;

            Exit:
            Console.WriteLine("Goodbye :)");
            System.Threading.Thread.Sleep(520);
        }
    }
}
