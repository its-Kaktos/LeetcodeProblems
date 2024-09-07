namespace ArrayProblems.Easy.SummaryRangesProblem;

/// <summary>
/// https://leetcode.com/problems/summary-ranges/description/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();
        var minIndex = -1;
        for (var i = 0; i < nums.Length; i++)
        {
            if (minIndex == -1) minIndex = i;
            if (i < nums.Length - 1 && nums[i] + 1 == nums[i + 1]) continue;

            var str = nums[minIndex] + (minIndex != i ? $"->{nums[i]}" : "");
            result.Add(str);
            minIndex = -1;
        }

        if (minIndex != -1)
        {
            var lastIndex = nums.Length - 1;
            var str = nums[minIndex] + (minIndex != lastIndex ? $"->{nums[lastIndex]}" : "");
            result.Add(str);
        }

        return result;
    }
}