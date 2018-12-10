using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
  public class Puzzle09
  {

    private class Marble
    {
      public int Id { get; set; }
      public Marble Left { get; set; }
      public Marble Right { get; set; }
    }

    public static void Run1()
    {
      var playerCount = 463;
      var maxMarbleCount = 71787 * 100;

      var currentMarble = new Marble { Id = 0 };
      currentMarble.Right = currentMarble;
      currentMarble.Left = currentMarble;

      var scores = new Dictionary<int, long>();
      for(int i = 1; i <= playerCount; i++)
      {
        scores.Add(i, 0);
      }

      long highScore = 0;
      var marbleCount = 1;
      var currentPlayer = 1;
   
      while(marbleCount <= maxMarbleCount)
      {
        if (marbleCount % 23 == 0)
        {
          scores[currentPlayer] += marbleCount;
          var marbleToRemove = currentMarble.Left.Left.Left.Left.Left.Left.Left;
          scores[currentPlayer] += marbleToRemove.Id;
          marbleToRemove.Left.Right = marbleToRemove.Right;
          marbleToRemove.Right.Left = marbleToRemove.Left;
          currentMarble = marbleToRemove.Right;
          marbleToRemove.Left = null;
          marbleToRemove.Right = null;
          marbleToRemove = null;
        }
        else
        {
          if (marbleCount < 3)
          {
            while (currentMarble.Id != 0)
            {
              currentMarble = currentMarble.Right;
            }
          }
          else
          {
            currentMarble = currentMarble.Right;
          }

          var newMarble = new Marble() { Id = marbleCount, Left = currentMarble, Right = currentMarble.Right };
          currentMarble.Right = newMarble;
          newMarble.Right.Left = newMarble;
          currentMarble = newMarble;
        }

        highScore = scores.Values.Max();

        marbleCount++;
        currentPlayer++;
        if (currentPlayer > playerCount)
        {
          currentPlayer = 1;
        }

        //DebugOutput(currentMarble, currentPlayer);

        if (marbleCount <= maxMarbleCount)
        {
          Console.Write("\r" + marbleCount + " of " + maxMarbleCount + " High Score: " + highScore);
        }
      }

      Console.WriteLine("");
      foreach (var key in scores.Keys)
      {
        Console.WriteLine("Player: " + key + " Score: " + scores[key]);
      }
    }

    private static void DebugOutput(Marble currentMarble, int currentPlayer)
    {
      var currentPrintMarble = currentMarble;
      while (currentMarble.Id != 0)
      {
        currentPrintMarble = currentPrintMarble.Right;
      }
      var output = new StringBuilder();
      var backToStart = false;
      while (!backToStart)
      {
        if (currentPrintMarble.Id == 0)
        {
          output.Append("[" + (currentPlayer - 1) + "]");
        }

        if (currentMarble.Id == currentPrintMarble.Id)
        {
          output.Append(" (" + currentPrintMarble.Id + ")");
        }
        else
        {
          output.Append(" " + currentPrintMarble.Id);
        }
        currentPrintMarble = currentPrintMarble.Right;
        if (currentPrintMarble.Id == 0)
        {
          backToStart = true;
        }
      }

      Console.WriteLine(output.ToString());
    }

    private static string Input()
    {
      return @"463 players; last marble is worth 71787 points";
    }
  }
}
