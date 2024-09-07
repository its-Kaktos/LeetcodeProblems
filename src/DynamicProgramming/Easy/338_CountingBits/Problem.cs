namespace DynamicProgramming.Easy._338_CountingBits;

/// <summary>
/// https://leetcode.com/problems/counting-bits?envType=problem-list-v2&envId=dynamic-programming&difficulty=EASY
/// </summary>
public class Problem
{
    /// <summary>
    /// This answer is inspired by an answer i've seen on Leetcode.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] CountBits(int n)
    {
        var result = new int[n + 1];
        for (var i = 1; i <= n; i++)
        {
            // result[i] = result[i / 2];
            //
            // if (i % 2 == 1) result[i] += 1;

            // result[i] = result[i / 2] + (i % 2);

            if (i % 2 == 0)
            {
                result[i] = result[i / 2];
                continue;
            }

            result[i] += result[i - 1] + 1;
        }

        return result;
    }

    /// <summary>
    /// This is my original WORKING answer.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] CountBitsOrg(int n)
    {
        if (n == 0) return [0];

        var memo = new Dictionary<int, int>()
        {
            { 0, 0 }
        };

        var result = new int[n + 1];
        for (var i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                result[i] = memo[i / 2];
                memo.Add(i, result[i]);

                continue;
            }

            result[i] = memo[i / 2] + 1;
            memo.Add(i, result[i]);
        }

        return result;
    }
}