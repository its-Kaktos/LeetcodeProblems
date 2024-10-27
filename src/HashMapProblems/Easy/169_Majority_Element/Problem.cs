namespace HashMapProblems.Easy._169_Majority_Element;

/// <summary>
///  https://leetcode.com/problems/majority-element/
/// </summary>
public class Problem
{
    public int MajorityElement(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        Array.Sort(nums);

        var maxCount = 0;
        var maxNum = int.MinValue;

        var currentCount = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] == nums[i])
            {
                currentCount++;
                continue;
            }

            if (currentCount < maxCount)
            {
                currentCount = 1;
                continue;
            }

            maxCount = currentCount;
            maxNum = nums[i - 1];
            currentCount = 0;
        }

        return currentCount < maxCount ? maxNum : nums[^1];
    }
}