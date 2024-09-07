namespace ArrayProblems.Easy.SingleNumberProblem;

/// <summary>
/// https://leetcode.com/problems/single-number/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    /// <summary>
    /// This is not my answer, kind of. I've seen an image in Leetcode that sparked this answer. its brilliant!
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int SingleNumber(int[] nums)
    {
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            result ^= nums[i];
        }

        return result;
    }
}