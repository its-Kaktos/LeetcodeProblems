namespace HashMapProblems.Medium._49_Group_Anagrams;

/// <summary>
///  https://leetcode.com/problems/group-anagrams/description/
/// </summary>
public class Problem
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();
        
        foreach (var s in strs)
        {
            var array = s.ToCharArray();
            Array.Sort(array);

            var sorted = new string(array);
            
            if (map.TryGetValue(sorted, out var value))
            {
                value.Add(s);
                continue;
            }
            
            map.Add(sorted, [s]);
        }

        return map.Values.ToList();
    }
}