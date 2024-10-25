namespace StringsProblems.Easy;

public class LongestCommonPrefix
{
    /// <summary>
    /// https://leetcode.com/problems/longest-common-prefix/
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public string method(string[] strs)
    {
        if (strs.Length == 0)
        {
            return "";
        }

        if (strs.Length == 1 || strs[0].Length == 0)
        {
            return strs[0];
        }

        var current = strs[0];
        var longestIndex = -1;

        var min = strs[1].Length < current.Length ? strs[1].Length : current.Length;
        for (var i = 0; i < min; i++)
        {
            if (current[0] != strs[1][0])
            {
                return "";
            }

            if (current[i] != strs[1][i])
            {
                break;
            }
            
            longestIndex = i;
        }

        if (strs.Length == 2)
        {
            return longestIndex == -1 ? "" : current.Substring(0, longestIndex + 1);
        }


        for (var i = 2; i < strs.Length; i++)
        {
            var currentLongestIndex = 0;

            if (strs[i].Length == 0)
            {
                return "";
            }

            min = strs[i].Length < current.Length ? strs[i].Length : current.Length;
            for (int j = 0; j < min; j++)
            {
                if (current[0] != strs[i][0])
                {
                    return "";
                }

                if (current[j] != strs[i][j])
                {
                    break;
                }
                
                currentLongestIndex = j;
            }

            if (longestIndex > currentLongestIndex)
            {
                longestIndex = currentLongestIndex;
            }
        }

        if (longestIndex == -1)
        {
            return "";
        }

        return current.Substring(0, longestIndex + 1);
    }
}