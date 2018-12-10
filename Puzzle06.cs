using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MoreLinq;

namespace AdventOfCode
{
  public class Puzzle06
  {
    private class GridData
    {
      public int CoordinateId { get; set; }

      public int Distance { get; set; }
    }

    public static void Run1()
    {
      var coordinates = ParseInput();
      var gridWidth = coordinates.Values.Max(o => o.Item1);
      var gridHeight = coordinates.Values.Max(o => o.Item2);
      var grid = new Dictionary<int, Dictionary<int, List<GridData>>>();
      var gridNearest = new Dictionary<int, Dictionary<int, int>>();

      for (var i = 0; i <= gridWidth; i++)
      {
        var column = new Dictionary<int, List<GridData>>();
        var columnNearest = new Dictionary<int, int>();
        for (var ii = 0; ii <= gridHeight; ii++)
        {
          column.Add(ii, new List<GridData>());
          columnNearest.Add(ii, 0);
        }
        grid.Add(i, column);
        gridNearest.Add(i, columnNearest);
      }

      foreach (var key in coordinates.Keys)
      {
        foreach (var x in grid.Keys)
        {
          foreach (var y in grid[x].Keys)
          {
            var manhattan = ManhattanDistance(coordinates[key].Item1, x, coordinates[key].Item2, y);
            grid[x][y].Add(new GridData {CoordinateId = key, Distance = manhattan});
          }
        }
      }

      foreach (var x in grid.Keys)
      {
        foreach (var y in grid[x].Keys)
        {
           
          var distances = grid[x][y];
          var minDistance = distances.Min(o => o.Distance);
          var minCoordinates = distances.Where(o => o.Distance == minDistance).ToList();
          if (minCoordinates.Count() != 1)
          {
            gridNearest[x][y] = 0;
          }
          else
          {
            gridNearest[x][y] = minCoordinates.Single().CoordinateId;
          }
        }
      }

      var infinites = new List<int>();
      for(var i = 0; i <= gridWidth; i++)
      {
        if (i == 0 || i == gridWidth)
        {
          for(var ii = 0; ii <= gridHeight; ii++)
          {
            infinites.Add(gridNearest[i][ii]);
          }
        }
        else
        {
          infinites.Add(gridNearest[i][0]);
          infinites.Add(gridNearest[i][gridHeight]);
        }
      }

      var counts = new Dictionary<int, int>();
      
      foreach (var x in gridNearest.Keys)
      {
        foreach (var y in gridNearest[x].Keys)
        {
          var coordinate = gridNearest[x][y];
          if (!infinites.Contains(coordinate) && coordinate != 0)
          {
            if (!counts.ContainsKey(coordinate))
            {
              counts.Add(coordinate,1);
            }
            else
            {
              counts[coordinate] += 1;
            }
          }
        }
      }

      var biggestArea = counts.Values.Max();

      Console.WriteLine(biggestArea);
    }

    public static void Run2()
    {
      var coordinates = ParseInput();
      var gridWidth = coordinates.Values.Max(o => o.Item1);
      var gridHeight = coordinates.Values.Max(o => o.Item2);
      var grid = new Dictionary<int, Dictionary<int, List<GridData>>>();
      var gridNearest = new Dictionary<int, Dictionary<int, int>>();

      for (var i = 0; i <= gridWidth; i++)
      {
        var column = new Dictionary<int, List<GridData>>();
        var columnNearest = new Dictionary<int, int>();
        for (var ii = 0; ii <= gridHeight; ii++)
        {
          column.Add(ii, new List<GridData>());
          columnNearest.Add(ii, 0);
        }
        grid.Add(i, column);
        gridNearest.Add(i, columnNearest);
      }

      foreach (var key in coordinates.Keys)
      {
        foreach (var x in grid.Keys)
        {
          foreach (var y in grid[x].Keys)
          {
            var manhattan = ManhattanDistance(coordinates[key].Item1, x, coordinates[key].Item2, y);
            grid[x][y].Add(new GridData { CoordinateId = key, Distance = manhattan });
          }
        }
      }

      var countSafe = 0;

      foreach (var x in grid.Keys)
      {
        foreach (var y in grid[x].Keys)
        {

          var distances = grid[x][y];
          var total = distances.Sum(o => o.Distance);
          if (total < 10000)
          {
            countSafe += 1;
          }
        }
      }

      Console.WriteLine(countSafe);
    }

    private static Dictionary<int, Tuple<int, int>> ParseInput()
    {
      var result = new Dictionary<int, Tuple<int, int>>();
      var Id = 1;
      foreach (var item in Input().Split(Environment.NewLine))
      {
        var split = item.Split(',');
        result.Add(Id, new Tuple<int, int>(Convert.ToInt32(split[0]), Convert.ToInt32(split[1])));
        Id++;
      }
      return result;
    }

    public static int ManhattanDistance(int x1, int x2, int y1, int y2)
    {
      return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }

    public static string Input()
    {
      return @"63, 142
190, 296
132, 194
135, 197
327, 292
144, 174
103, 173
141, 317
265, 58
344, 50
184, 238
119, 61
329, 106
70, 242
272, 346
312, 166
283, 351
286, 206
57, 225
347, 125
152, 186
131, 162
45, 299
142, 102
61, 100
111, 218
73, 266
350, 173
306, 221
42, 284
150, 122
322, 286
346, 273
75, 354
68, 124
194, 52
92, 44
77, 98
77, 107
141, 283
87, 306
184, 110
318, 343
330, 196
303, 353
268, 245
180, 220
342, 337
127, 107
203, 127";
    }
  }
}
