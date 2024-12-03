


namespace day2
{
  internal class Program
  {

    static void Main()
    {
      IEnumerable<string> input = File.ReadLines("input.txt");
      List<List<int>> result = new List<List<int>>();
      bool? listUP;
      int totalSafe = 0;



      foreach (string line in input)
      {
        List<int> intsList = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        result.Add(intsList);
      }

      foreach (List<int> list in result) // Voor elke rij in results
      {

        listUP = GoesUp(list[0], list[1]); // Check of de rij omhoog of omlaagmoet.
        if (listUP == null) continue;




        for (int i = 0; i < list.Count - 1; i++) // Voor elk item in de rij voor checks uit
        {
          if (GoesUp(list[i], list[i + 1]) != listUP)
          {
            break; // Als de waardes niet gelijk zijn aan elkaar gaat deze combinatie niet altijd naar boven of beneden.
          }

          int diff = Difference(list[i], list[i + 1], listUP);

          if (diff > 0 && diff < 4)
          {
            totalSafe++;
          }
          else
          {
            break; // Te groot verschil, niet veilig.
          }



        }
        Console.WriteLine(totalSafe);
      }



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