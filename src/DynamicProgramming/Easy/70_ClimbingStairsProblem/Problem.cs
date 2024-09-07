namespace DynamicProgramming.Easy._70_ClimbingStairsProblem;

/// <summary>
/// https://leetcode.com/problems/climbing-stairs/?envType=problem-list-v2&envId=dynamic-programming&difficulty=EASY
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=Y0lT9Fck7qI
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int ClimbStairs(int n)
    {
        var one = 1;
        var two = 1;

        for (var i = 0; i < n - 1; i++)
        {
            var temp = one;
            one += two;
            two = temp;
        }

        return one;
    }
    
    /// <summary>
    /// This is my original WORKING solution.
    /// This algorithm is apparently called DFS and im using memoization too. 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int ClimbStairsOrg(int n)
    {
        var memo = new Dictionary<int, int>();
        return ClimbStairsInternal(n, memo);
    }

    public int ClimbStairsInternal(int n, Dictionary<int, int> memo)
    {
        if (n is 0 or 1) return 1;

        var count = 0;
        if (memo.TryGetValue(n - 1, out var result))
        {
            count += result;
        }
        else
        {
            count += ClimbStairsInternal(n - 1, memo);
            memo.Add(n - 1, count);
        }

        if (memo.TryGetValue(n - 2, out result))
        {
            count += result;
        }
        else
        {
            count += ClimbStairsInternal(n - 2, memo);
            memo.Add(n - 2, count);
        }

        return count;
    }
}