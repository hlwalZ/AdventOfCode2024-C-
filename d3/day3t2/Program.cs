using System.Text.RegularExpressions;

namespace day3t2
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

      List<int> doIndexes = dos.Cast<Match>().Select(m => m.Index).ToList();
      List<int> dontIndexes = dont.Cast<Match>().Select(m => m.Index).ToList();
      int doIndex = 0;
      int dontIndex = 0;

      bool state = true;
      bool lastDo = false;

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

      for (int i = 0; i < amount.Count; i++) // Voor elke mol
      {
        if (amount[i].Value == null) continue;

        while (amount[i].Index > doIndexes[doIndex] && doIndex != dos.Count - 1 && state == true) doIndex++;


        if (amount[i].Index >= dontIndexes[dontIndex] && amount[i].Index <= doIndexes[doIndex])
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Mol " + amount[i].Index + " afgekeurd want do: " + doIndexes[doIndex] + " dont: " + dontIndexes[dontIndex]);
          Console.ResetColor();
          state = false;
          continue;
        }

        if (doIndex == dos.Count - 1) { lastDo = true; } // Eerlijk deze extra logica checks zijn echt zo vies, we hadden het kunnen hardcoden.
        if (lastDo == true && amount[i].Index > dontIndexes[dontIndex]) break;   // if (amount[i].Index > 16187) break; hardcoden zou nog viezer zijn maar ok.
        // Volgende keer wat minder simpele logica toepassen, dit is echt insane.
        // Dit is alleen ontstaan doordat de logica alleen maar een state is en er eigenlijk iets meer gevallen blijken te zijn...

        while (amount[i].Index > dontIndexes[dontIndex] && dontIndex != dont.Count - 1) dontIndex++;





        state = true;
        Console.WriteLine("Mol " + amount[i].Index + " goedgekeurd want do: " + doIndexes[doIndex] + " dont: " + dontIndexes[dontIndex]);

        MatchCollection smallCollection = Regex.Matches(amount[i].ToString(), pattern2);
        for (int l = 0; l < smallCollection.Count; l++)
        {
          string[] numbers = smallCollection[l].ToString().Split(",").ToArray();
          count += (double.Parse(numbers[0]) * double.Parse(numbers[1]));
        }
      }
      Console.WriteLine(count);
    }
  }
}