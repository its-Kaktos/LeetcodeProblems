namespace ArrayProblems.Medium._238_ProductOfArrayExceptSelf;

/// <summary>
///  https://leetcode.com/problems/product-of-array-except-self/description/
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=bNvIQI2wAjk&ab_channel=NeetCode
    ///
    /// Code is written using the explanation in the video
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];

        // Calculate prefix
        result[0] = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        var postfix = 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= postfix;
            postfix *= nums[i];
        }

        return result;
    }
}