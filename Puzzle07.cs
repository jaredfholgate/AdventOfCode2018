using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace AdventOfCode
{
  public class Puzzle07
  {

    private class GraphNode
    {
      public string Step { get; set; }

      public List<GraphNode> DependentSteps { get; set; }
      
    }

    public static void Run1()
    {
      var input = ParseInput();

      var result = new StringBuilder();
      
      var availableSteps = input.Where(o => o.DependentSteps.Count == 0).ToList();

      var completedSteps = new List<string>();

      while (availableSteps.Count > 0)
      {
        var nextStep = availableSteps.OrderBy(o => o.Step).First();
        completedSteps.Add(nextStep.Step);
        result.Append(nextStep.Step);
        availableSteps = input.Where(o => o.DependentSteps.All(oo => completedSteps.Contains(oo.Step)) && !completedSteps.Contains(o.Step)).ToList();
      }

      Console.WriteLine(result.ToString());
    }

    private class StepTime
    {
      public int TotalTime { get; set; }
      public int TimeTaken { get; set; }
    }

    public static void Run2()
    {
      var input = ParseInput();

      var result = new StringBuilder();

      var availableSteps = input.Where(o => o.DependentSteps.Count == 0).ToList();

      var completedSteps = new List<string>();

      var stepTimes = new Dictionary<string, StepTime>();
      var time = 61;
      for (var letter = 'A'; letter <= 'Z'; letter++)
      {
        stepTimes.Add(letter.ToString(), new StepTime { TotalTime = time, TimeTaken = 0 });
        time++;
      }

      var overallTime = 0;
      while (availableSteps.Count > 0)
      {
        var nextSteps = availableSteps.OrderBy(o => o.Step).Take(5).ToList();
        foreach (var step in nextSteps)
        {
          stepTimes[step.Step].TimeTaken++;
          if (stepTimes[step.Step].TimeTaken == stepTimes[step.Step].TotalTime)
          {
            completedSteps.Add(step.Step);
            result.Append(step.Step);
          }
        }
        
        availableSteps = input.Where(o => o.DependentSteps.All(oo => completedSteps.Contains(oo.Step)) && !completedSteps.Contains(o.Step)).ToList();
      
        overallTime++;
      }

      Console.WriteLine(overallTime);
    }

    private static List<GraphNode> ParseInput()
    {
      var nodes = new List<GraphNode>();
      foreach (var item in Input().Split(Environment.NewLine))
      {
        var split = item.Split(' ');
        var parent = split[1];
        var child = split[7];

        GraphNode childNode;
        GraphNode parentNode;

        if (!nodes.Any(o => o.Step == child))
        {
          childNode = new GraphNode() { Step = child, DependentSteps = new List<GraphNode>()};
          nodes.Add(childNode);
        }
        else
        {
          childNode = nodes.Single(o => o.Step == child);
        }

        if (!nodes.Any(o => o.Step == parent))
        {
          parentNode = new GraphNode() { Step = parent, DependentSteps = new List<GraphNode>() };
          nodes.Add(parentNode);
        }
        else
        {
          parentNode = nodes.Single(o => o.Step == parent);
        }

        childNode.DependentSteps.Add(parentNode);
      }
      return nodes;
    }

    private static string Input()
    {
      return @"Step X must be finished before step Q can begin.
Step Y must be finished before step P can begin.
Step U must be finished before step F can begin.
Step V must be finished before step S can begin.
Step G must be finished before step R can begin.
Step T must be finished before step P can begin.
Step O must be finished before step D can begin.
Step R must be finished before step I can begin.
Step M must be finished before step F can begin.
Step L must be finished before step C can begin.
Step K must be finished before step H can begin.
Step D must be finished before step H can begin.
Step I must be finished before step W can begin.
Step S must be finished before step C can begin.
Step J must be finished before step Z can begin.
Step B must be finished before step A can begin.
Step A must be finished before step W can begin.
Step W must be finished before step F can begin.
Step P must be finished before step E can begin.
Step C must be finished before step Q can begin.
Step E must be finished before step Z can begin.
Step Q must be finished before step F can begin.
Step Z must be finished before step F can begin.
Step N must be finished before step H can begin.
Step H must be finished before step F can begin.
Step N must be finished before step F can begin.
Step K must be finished before step D can begin.
Step P must be finished before step F can begin.
Step Q must be finished before step Z can begin.
Step G must be finished before step W can begin.
Step E must be finished before step N can begin.
Step R must be finished before step Z can begin.
Step V must be finished before step R can begin.
Step Q must be finished before step N can begin.
Step U must be finished before step L can begin.
Step P must be finished before step N can begin.
Step S must be finished before step Q can begin.
Step G must be finished before step S can begin.
Step U must be finished before step E can begin.
Step M must be finished before step I can begin.
Step A must be finished before step N can begin.
Step W must be finished before step H can begin.
Step J must be finished before step A can begin.
Step M must be finished before step S can begin.
Step T must be finished before step I can begin.
Step E must be finished before step Q can begin.
Step C must be finished before step Z can begin.
Step B must be finished before step H can begin.
Step J must be finished before step F can begin.
Step G must be finished before step E can begin.
Step Q must be finished before step H can begin.
Step T must be finished before step B can begin.
Step V must be finished before step B can begin.
Step R must be finished before step F can begin.
Step V must be finished before step H can begin.
Step K must be finished before step N can begin.
Step A must be finished before step H can begin.
Step S must be finished before step E can begin.
Step I must be finished before step N can begin.
Step V must be finished before step I can begin.
Step M must be finished before step E can begin.
Step U must be finished before step G can begin.
Step J must be finished before step N can begin.
Step T must be finished before step K can begin.
Step D must be finished before step N can begin.
Step L must be finished before step S can begin.
Step P must be finished before step Z can begin.
Step X must be finished before step S can begin.
Step B must be finished before step W can begin.
Step R must be finished before step M can begin.
Step W must be finished before step Q can begin.
Step A must be finished before step Z can begin.
Step A must be finished before step F can begin.
Step G must be finished before step T can begin.
Step S must be finished before step A can begin.
Step J must be finished before step E can begin.
Step Y must be finished before step N can begin.
Step D must be finished before step J can begin.
Step D must be finished before step S can begin.
Step M must be finished before step W can begin.
Step U must be finished before step T can begin.
Step E must be finished before step H can begin.
Step S must be finished before step W can begin.
Step T must be finished before step C can begin.
Step A must be finished before step P can begin.
Step U must be finished before step V can begin.
Step U must be finished before step J can begin.
Step L must be finished before step B can begin.
Step L must be finished before step N can begin.
Step J must be finished before step C can begin.
Step L must be finished before step Q can begin.
Step K must be finished before step B can begin.
Step G must be finished before step H can begin.
Step W must be finished before step Z can begin.
Step C must be finished before step E can begin.
Step B must be finished before step Q can begin.
Step O must be finished before step Z can begin.
Step L must be finished before step J can begin.
Step R must be finished before step N can begin.
Step J must be finished before step P can begin.
Step Y must be finished before step F can begin.";
    }
  }
}
