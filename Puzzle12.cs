using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace AdventOfCode
{
  public class Puzzle12
  {
    private const string InitialState = "#.####...##..#....#####.##.......##.#..###.#####.###.##.###.###.#...#...##.#.##.#...#..#.##..##.#.##";

    private const string TestInitialState = "#..#.#..##......###...###";

    private const long Generations = 1000;

    public static void Run1()
    {
        // long result = 74022 + (72 * (50000000000 - 1000));
        // Console.WriteLine(result);
        // return;

        var combinations = ParseCombinations();
        
        var currentState = ParseState(InitialState);
        long generation = 1;
        while(generation <= Generations)
        {
            var newState = new Dictionary<int, bool>();
            for(int i = currentState.Keys.Min() - 5; i < currentState.Keys.Max() + 5; i++)
            {
                var test = new List<bool>();
                for(int ii = i -2; ii <= i + 2; ii++)
                {
                    if(!currentState.ContainsKey(ii))
                    {
                        test.Add(false);
                    }
                    else
                    {
                        test.Add(currentState[ii]);
                    }
                }

                foreach(var combination in combinations.Where(o => o.ProducesPlant))
                {
                    if(combination.IsMatch(test))
                    {
                        newState.Add(i, true);
                        break;
                    }
                }
            }

            currentState = newState;
            Console.WriteLine(generation + ": " + OutputGeneration(currentState));
            generation++;
        }
        var plantCount = currentState.Where(o => o.Value == true).Select(o => o.Key).Sum();

        Console.WriteLine(plantCount);
    }

    private static string OutputGeneration(Dictionary<int, bool> generation)
    {
        var output = new StringBuilder();

        for(int i = generation.Keys.Min(); i < generation.Keys.Max(); i++)
        {
            output.Append(generation.ContainsKey(i) ? "#" : ".");
        }

        return output.ToString();
    }

    private class Pattern
    {
        public bool ProducesPlant {get;set;}

        public List<bool> Combination { get; set;}

        public bool IsMatch(List<bool> pattern)
        {
            for(var i = 0; i < 5; i++)
            {
                if(Combination[i] != pattern[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    private static List<Pattern> ParseCombinations()
    {
        var patterns = new List<Pattern>();
        foreach(var line in Input().Split(Environment.NewLine))
        {
            var split = line.Split("=>");
            patterns.Add(new Pattern { Combination = split[0].Trim().ToArray().Select(o => o == '#').ToList(), ProducesPlant = split[1].Trim() == "#" });
        }

        return patterns;
    }

    private static Dictionary<int,bool> ParseState(string stateToParse)
    {
        var state = new Dictionary<int,bool>();
        var index = 0;
        foreach(var plant in stateToParse)
        {
            if(plant == '#')
            {
                state.Add(index, true);
            }
            index++;
        }
        
        return state;
    }


    private static string TestInput()
    {
        return @"...## => #
..#.. => #
.#... => #
.#.#. => #
.#.## => #
.##.. => #
.#### => #
#.#.# => #
#.### => #
##.#. => #
##.## => #
###.. => #
###.# => #
####. => #";
    }

    private static string Input()
    {
        return @".##.. => .
..##. => #
.#..# => #
.#.#. => .
..#.. => #
###.. => #
##..# => .
##... => #
#.### => #
.##.# => #
#.... => .
###.# => .
..... => .
.#... => #
....# => .
#.#.. => .
...#. => #
#...# => .
##.#. => .
.#.## => #
..#.# => #
#.#.# => .
.#### => .
##### => .
..### => .
...## => .
#..## => .
#.##. => .
#..#. => #
.###. => #
##.## => #
####. => .";
    }
  }
}