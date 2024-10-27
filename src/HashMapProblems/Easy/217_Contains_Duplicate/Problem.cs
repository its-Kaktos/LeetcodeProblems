namespace HashMapProblems.Easy._217_Contains_Duplicate;

/// <summary>
///  https://leetcode.com/problems/contains-duplicate/description/
/// </summary>
public class Problem
{
    // We can solve this question using sorting and hashmap and XOR
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (set.Contains(nums[i])) return true;

            set.Add(nums[i]);
        }

        return false;
    }
}