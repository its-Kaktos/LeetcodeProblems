namespace ArrayProblems.Medium._16_3Sum_Closest;

/// <summary>
///  https://leetcode.com/problems/3sum-closest/?envType=problem-list-v2&envId=array&difficulty=MEDIUM
/// </summary>
public class Problem
{
    /// <summary>
    /// My original WORKING answer
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);

        int? result = null;
        int? resultDiff = null;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i + 2 >= nums.Length) break;

            var low = i + 1;
            var high = nums.Length - 1;

            while (low < high)
            {
                var sum = nums[i] + nums[low] + nums[high];
                var diff = Math.Abs(sum - target);
                if (result is null || diff < resultDiff)
                {
                    result = sum;
                    resultDiff = diff;
                }

                if (sum > target)
                    high--;
                else if(sum < target)
                    low++;
                else 
                    break;
            }
        }

        return result ?? 0;
    }
}