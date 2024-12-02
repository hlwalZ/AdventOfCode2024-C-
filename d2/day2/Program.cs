


namespace day2
{
  internal class Program
  {

    static void Main()
    {
      IEnumerable<string> input = File.ReadLines("input2.txt");
      List<List<int>> result = new List<List<int>>();
      bool? listUP;
      bool flagSafe = true;
      int totalSafe = 0;
      int amountNull = 0;
      int amountFalse = 0;


      foreach (string line in input)
      {
        List<int> intsList = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        result.Add(intsList);
      }
      int listIndex = 0;
      foreach (List<int> list in result) // Voor elke rij in results
      {
        foreach (int a in list)
        {
          Console.Write(a + " ");
        }

        listUP = GoesUp(list[0], list[1]); // Check of de rij omhoog of omlaagmoet.

        if (listUP == null)
        {
          amountNull++;
          flagSafe = false;
          Console.Write(" Dit is null \n");
          continue;
        }



        for (int i = 0; i < list.Count - 1; i++) // Voor elk item in de rij voor checks uit
        {
          if (GoesUp(list[i], list[i + 1]) != listUP)
          {
            flagSafe = false;
            break; // Als de waardes niet gelijk zijn aan elkaar gaat deze combinatie niet altijd naar boven of beneden.
          }

          int diff = Difference(list[i], list[i + 1], listUP);

          if (diff > 0 && diff < 4)
          {
            Console.Write("Dk");
            flagSafe = true;
          }
          else
          {
            Console.Write("Dg");
            flagSafe = false;
            break; // Te groot verschil, niet veilig.
          }
        }
        if (flagSafe == true)
        {
          totalSafe++;
          Console.Write(" Dit is positief \n");
        }
        else
        {
          amountFalse++;
          Console.Write(" Dit is false \n");
        }

      }
      Console.WriteLine(totalSafe);

      Console.WriteLine(amountNull);
      Console.WriteLine(amountFalse);

    }

    static Nullable<bool> GoesUp(int a, int b)
    {
      if (a < b)
      {
        return true; // Up
      }
      else if (a > b)
      {
        return false; // Down
      }
      else
      {
        return null; // Unsafe
      }
    }

    static int Difference(int a, int b, bool? listUP)
    {
      if (listUP == true)
      {
        return b - a;
      }
      else
      {
        return a - b;
      }
    }

  }
}