


namespace day2
{
  internal class Program
  {
    // If i = 2 en de richting is anders, verander de richting en - 1 leven
    // 

    static void Main()
    {
      IEnumerable<string> input = File.ReadLines("inputmini.txt");
      List<List<int>> result = new List<List<int>>();
      bool? listUP1;
      bool? listUP2;
      bool flagSafe = true;
      bool life = true;
      int totalSafe = 0;
      int amountNull = 0;
      int amountFalse = 0;


      foreach (string line in input)
      {
        List<int> intsList = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        result.Add(intsList);
      }

      foreach (List<int> list in result) // Voor elke rij in results
      {
        foreach (int number in list)
        {
          Console.Write(number + " ");
        }

        listUP1 = GoesUp(list[0], list[1]); // Check of de rij omhoog of omlaagmoet.
        listUP2 = GoesUp(list[1], list[2]); // Check of de tweede waarde zegt omhoog of omlaag

        if (listUP1 != listUP2 || listUP2 == null)
        {
          amountNull++;
          flagSafe = false;
          Console.Write(" Dit is null \n");
          continue;
        }



        for (int i = 0; i < list.Count - 1; i++) // Voor elk item in de rij voor checks uit
        {
          if (GoesUp(list[i], list[i + 1]) != listUP1)
          {
            flagSafe = false;
            break; // Als de waardes niet gelijk zijn aan elkaar gaat deze combinatie niet altijd naar boven of beneden.
          }


          int diff = Difference(list[i], list[i + 1], listUP1);
          flagSafe = DifferenceOK(diff);
          if (flagSafe == false)
          {
            break;
          }


        }
        if (flagSafe == true)
        {
          life = true;
          totalSafe++;
          Console.Write(" Dit is positief \n");
        }
        else
        {
          life = true;
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

    static int Difference(int a, int b, bool? listUP1)
    {
      if (listUP1 == true)
      {
        return b - a;
      }
      else
      {
        return a - b;
      }
    }

    static bool DifferenceOK(int diff)
    {

      if (diff > 0 && diff < 4)
      {
        Console.Write("DOK-");
        return true;
      }
      else
      {
        Console.Write("DNOK-");
        return false;

      }

    }

  }
}