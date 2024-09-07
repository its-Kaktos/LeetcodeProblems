namespace ArrayProblems.Easy.RemoveElementProblem;

/// <summary>
/// https://leetcode.com/problems/remove-element/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    // Input: nums = [0,1,2,2,3,0,4,2] 2
    // Output: 5, nums = [0,1,4,0,3]
    public int RemoveElement(int[] nums, int val)
    {
        var j = 0;
        var lastNum = nums.Length - 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[j] == val)
            {
                nums[j] = nums[lastNum];
                lastNum--;
                continue;
            }

            j++;
        }

        return j;
    }
}