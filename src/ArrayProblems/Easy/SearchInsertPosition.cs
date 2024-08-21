namespace ArrayProblems.Easy;

/// <summary>
/// https://leetcode.com/problems/search-insert-position/
/// </summary>
public class SearchInsertPosition
{
    public int SearchInsert(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;
        while (low <= high)
        {
            var mid = (low + high) / 2;

            if (nums[mid] == target) return mid;

            if (target < nums[mid])
            {
                high = mid - 1;
            }

            low = mid + 1;
        }

        return low;
    }
}