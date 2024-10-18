namespace ArrayProblems.Easy._561_Array_Partition;

/// <summary>
/// https://leetcode.com/problems/array-partition/description/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    // 6, 2, 6, 5, 1, 2
    public int ArrayPairSum(int[] nums)
    {
        // 1, 2, 2, 5, 6, 6
        Array.Sort(nums);

        var sum = 0;
        for (var i = 0; i < nums.Length; i += 2)
        {
            sum += nums[i];
        }

        return sum;
    }
}