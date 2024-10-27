namespace HashMapProblems.Easy._771_Jewels_and_Stones;

/// <summary>
///  https://leetcode.com/problems/jewels-and-stones/
/// </summary>
public class Problem
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        var set = new HashSet<char>();
        
        // We can use Linq, but avoiding Linq
        // will generally yield better performance.
        foreach (var jewel in jewels)
        {
            set.Add(jewel);
        }
        
        var output = 0;
        foreach (var stone in stones)
        {
            if (set.Contains(stone)) output++;
        }

        return output;
    }
}
