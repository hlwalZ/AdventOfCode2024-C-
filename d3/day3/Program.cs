

using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace day3
{
  internal class Program
  {
    static void Main()
    {
      double count = 0;

      string input = File.ReadAllText("input.txt");
      string pattern1 = @"mul\([0-9]{1,3},[0-9]{1,3}\)"; // Breekt wel als er een vermenigvuldiging van 0 in zit.
      string pattern2 = @"[0-9]{1,3},[0-9]{1,3}";
      string pattern3 = @"do\(\)";
      string pattern4 = @"don\'t\(\)";
      MatchCollection amount = Regex.Matches(input, pattern1);
      MatchCollection dos = Regex.Matches(input, pattern3);
      MatchCollection dont = Regex.Matches(input, pattern4);

      // For each, check of het > do is en < don't.

      // for (int i = 0; i < dos.Count; i++)
      // {
      //   Console.WriteLine(dos[i].Value + " " + dos[i].Index);
      // }

      int[] doIndexes;
      dos.CopyTo(doIndexes);

      Console.WriteLine(dos.Count);
      Console.WriteLine(dont.Count);
      Console.WriteLine(dos.First().Index); // Start
      Console.WriteLine(dont.First().Index); // Stop
      // Bool: allowed to count is de -- Creating a list out of MatchCollection where -- meh misschien maar niet.
      // We moeten wel eerst sorteren wanneer de nieuwste stop en wanneer de nieuwste start komt.

      // For each mol
      // While current index > do || don't ++ op de do of don't. -- Pas de indexes correct aan
      // If index > don't[i].index && index < do[i].index == negeer
      // else counter += mul;

      // Ga door tot de eerste stop,
      // Kijk dan wanneer pas weer mee te tellen vanaf de eerste do, if under start negeer
      // Kijk dan tot de eerste stop. if under stop ++

      for (int i = 0; i < amount.Count; i++)
      {
        if (amount[i].Value != null)
        {
          Console.WriteLine(amount[i].Value + " , index: " + amount[i].Index);
          MatchCollection smallCollection = Regex.Matches(amount[i].ToString(), pattern2);
          for (int l = 0; l < smallCollection.Count; l++)
          {
            string[] numbers = smallCollection[l].ToString().Split(",").ToArray();
            count += (double.Parse(numbers[0]) * double.Parse(numbers[1]));
          }
        }

      }
      Console.WriteLine(count);
    }
  }
}