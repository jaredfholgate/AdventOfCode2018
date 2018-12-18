using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace AdventOfCode
{
    using System.Linq;
    public class Puzzle11
    {
        private const int Serial = 5177;

        public class PowerPair
        {
            public int Power { get; set; }
            public int TotalPower { get; set; }
        }

        public static void Run1()
        {
            var grid = BuildGrid(Serial);

            var highestPower = 0;
            var highestPowerX = 0;
            var highestPowerY = 0;

            for (var x = 1; x <= 298; x++)
            {
                for (var y = 1; y <= 298; y++)
                {
                    var power = 0;
                    for (var x1 = x; x1 <= x + 2; x1++)
                    {
                        for (var y1 = y; y1 <= y + 2; y1++)
                        {
                            power += grid[x1][y1].Power;
                        }
                    }

                    grid[x][y].TotalPower = power;

                    if (power > highestPower)
                    {
                        highestPower = power;
                        highestPowerX = x;
                        highestPowerY = y;
                    }
                }
            }

            Console.WriteLine($"{highestPowerX},{highestPowerY}");
        }

        public class Power
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int TotalPower { get; set; }
            public int Size { get; set; }
        }

        public static int ThreadCount = 0;

        public static void Run2()
        {
            var grid = BuildGrid(Serial);

            var powers = new List<Power>();

            Console.WriteLine("Test");
            var tasks = new List<Task>();
            for (var x = 1; x <= 300; x++)
            {
                for (var y = 1; y <= 300; y++)
                {
                    Console.WriteLine($"{x},{y}");
                    var xPass = x;
                    var yPass = y;
                    tasks.Add(Task.Run(() => powers.Add(GetLargestPower(xPass, yPass, grid))));
                    lock (_lock)
                    {
                        ThreadCount++;
                    }
                }
            }

            Task.WaitAll(tasks.ToArray());

            var highestPower = powers.MaxBy(o => o.TotalPower).Single();

            Console.WriteLine($"Final: {highestPower.X},{highestPower.Y},{highestPower.Size}");
        }

        public static Power GetLargestPower(int x, int y, Dictionary<int, Dictionary<int, PowerPair>> grid)
        {
            var power = new Power { X = x, Y = y, Size = 0, TotalPower = 0 };
            var largest = x <= y ? y : x;

            var currentPower = 0;
            for (var size = 1; size <= 300 - largest; size++)
            {
                currentPower = GetPower(x, y, size, currentPower, grid);
                if (currentPower > power.TotalPower)
                {
                    power.Size = size;
                    power.TotalPower = currentPower;
                }
            }

            lock (_lock)
            {
                ThreadCount--;
            }
            Console.WriteLine($"Theads Remaining: {ThreadCount}");
            return power;
        }

        private static object _lock = new object();

        private static int GetPower(int x, int y, int size, int lastPower, Dictionary<int, Dictionary<int, PowerPair>> grid)
        {
            var power = lastPower;

            var xColumn = x + size - 1;
            var yRow = y + size - 1;

            for (var x1 = x; x1 <= (x + size) - 1; x1++)
            {
                power += grid[x1][yRow].Power;
            }

            for (var y1 = y; y1 <= ((y + size) - 2); y1++)
            {
                power += grid[xColumn][y1].Power;
            }

            return power;
        }

        public static Dictionary<int, Dictionary<int, PowerPair>> BuildGrid(int serial)
        {

            var grid = new Dictionary<int, Dictionary<int, PowerPair>>();
            for (var x = 1; x <= 300; x++)
            {
                var column = new Dictionary<int, PowerPair>();
                for (var y = 1; y <= 300; y++)
                {
                    column.Add(y, new PowerPair { Power = CalculatePower(x, y, serial), TotalPower = 0 });
                }
                grid.Add(x, column);
            }

            return grid;

        }

        private static int CalculatePower(int x, int y, int serial)
        {
            var rackId = x + 10;
            var power = rackId * y;
            power = power + serial;
            power = power * rackId;
            var powerString = power.ToString();
            var finalPower = (powerString.Length < 3 ? 0 : Convert.ToInt32(powerString.TakeLast(3).ToList()[0].ToString()));
            finalPower = finalPower - 5;
            return finalPower;
        }
    }
}
