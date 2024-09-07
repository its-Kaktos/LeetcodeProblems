namespace DynamicProgramming.Easy._746_MinCostClimbingStairs;

/// <summary>
/// https://leetcode.com/problems/min-cost-climbing-stairs/submissions/1381405059/?envType=problem-list-v2&envId=dynamic-programming&difficulty=EASY
/// </summary>
public class Problem
{
    /// <summary>
    /// This answer is inspired by the hints of the question,
    /// but to be honset, the 3 hints combined are kind of like
    /// having the complete answer!
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    public int MinCostClimbingStairs(int[] cost)
    {
        if (cost.Length == 2) return Math.Min(cost[0], cost[1]);

        for (var i = cost.Length - 3; i >= 0; i--)
        {
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }

        return Math.Min(cost[0], cost[1]);
    }

    /// <summary>
    /// My original WORKING answer but its SLOW.
    /// It probably will run faster if i use memoization technique.
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    public int MinCostClimbingStairsOrg(int[] cost)
    {
        return Math.Min(MinCostClimbingStairsInternal(cost, 0),
            MinCostClimbingStairsInternal(cost, 1));
    }

    public int MinCostClimbingStairsInternal(int[] cost, int index)
    {
        if (index == cost.Length - 1) return cost[^1];
        if (index >= cost.Length - 1) return 0;

        var f = MinCostClimbingStairsInternal(cost, index + 1);
        var s = MinCostClimbingStairsInternal(cost, index + 2);

        return cost[index] + Math.Min(f, s);
    }
}