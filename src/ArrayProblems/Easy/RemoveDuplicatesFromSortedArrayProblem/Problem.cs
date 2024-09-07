namespace ArrayProblems.Easy.RemoveDuplicatesFromSortedArrayProblem;

/// <summary>
/// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    /// <summary>
    /// My original working answer is below.
    /// https://www.youtube.com/watch?v=dIzcHKy5FkI
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates(int[] nums)
    {
        var j = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1]) continue;

            nums[j] = nums[i];
            j++;
        }

        return j;
    }

    public int RemoveDuplicatesOrg(int[] nums)
    {
        var count = 0;
        var maxNumSeen = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == int.MaxValue) continue;

            if (nums[i] > maxNumSeen)
            {
                maxNumSeen = nums[i];
                count++;
                continue;
            }

            nums[i] = int.MaxValue;
        }

        var insertAt = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == int.MaxValue) continue;

            (nums[i], nums[insertAt]) = (nums[insertAt], nums[i]);

            insertAt++;
        }

        return count;
    }
}