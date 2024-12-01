namespace day1
{
  internal class Program
  {

    static void Main()
    {
      int totalDifference = 0;
      IEnumerable<string> lines = File.ReadLines("input.txt");

      int totalTimes = 0;

      foreach (string line in lines)
      {
        string[] map = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        totalDifference += Difference(map);
        Console.WriteLine(totalDifference);
        totalTimes++;
      }
      Console.WriteLine(totalTimes);
      Console.WriteLine(totalDifference);
    }

    static int Difference(string[] map)
    {
      List<int> intListA = new();
      List<int> intListB = new();

      for (int i = 0; i < map.Length; i++) // Sorteer de twee strings naar twee cijfer lijsten.
      {
        if (i == 0)
        {
          foreach (char Karakter in map[i])
          {
            intListA.Add(Karakter - 48);
          }
        }
        else
        {
          foreach (char Karakter in map[i])
          {
            intListB.Add(Karakter - 48);
          }
        }
      } // Vieze logica
      foreach (int ints in intListA)
      {
        Console.Write(ints);
      }
      Console.Write(" ");
      foreach (int ints in intListB)
      {
        Console.Write(ints);
      }
      Console.Write(" ");
      intListA = BubbleSort(intListA);
      intListB = BubbleSort(intListB);

      int difference = 0;
      for (int counter = 0; counter < intListA.Count; counter++)
      {

        if (intListA[counter] >= intListB[counter])
        {
          difference += intListA[counter] - intListB[counter];
        }
        else
        {
          difference += intListB[counter] - intListA[counter];
        }
        // if (difference < 0)
        // {
        //   difference = -difference;
        // } // Jammer dat uint hier niet werkt, veroorzaakt een underflow :(
      }
      Console.Write(difference + ": "); // Difference tussen elke lijn
      return difference;
    }


    static List<int> BubbleSort(List<int> unsortedInts)
    {
      bool unsortedFlag = true;
      int numerator = unsortedInts.Count - 1;
      while (unsortedFlag)
      {
        unsortedFlag = false; // Misschien een beetje obscuur maar in mijn programma werkt het eenmaal zo.
        for (int i = 0; i < numerator; i++)
        {
          if (unsortedInts[i] > unsortedInts[i + 1])
          {
            (unsortedInts[i + 1], unsortedInts[i]) = (unsortedInts[i], unsortedInts[i + 1]); // Tuple! 
            unsortedFlag = true; // We weten niet of de lijst is gesorteerd totdat we geen grotere waardes tegenkomen.
          }
        }
      }
      foreach (int ints in unsortedInts)
      {
        Console.Write(ints);
      }
      Console.Write(" ");
      return unsortedInts;
    }
  }
}