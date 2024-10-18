namespace ArrayProblems.Easy._2239_FindClosestNumberToZero;

/// <summary>
/// https://leetcode.com/problems/find-closest-number-to-zero/
/// </summary>
public class Problem
{
    public int FindClosestNumber(int[] nums)
    {
        var answer = int.MaxValue;
        var answerActualValue = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
            var current = Math.Abs(nums[i]);
            if (current < answer)
            {
                answer = current;
                answerActualValue = nums[i];
                continue;
            }

            if (current == answer && answerActualValue < nums[i])
            {
                answer = current;
                answerActualValue = nums[i];
            }
        }

        return answerActualValue;
    }
}