using System.Text;

namespace StringsProblems.Easy._1768_Merge_Strings_Alternately;

/// <summary>
/// https://leetcode.com/problems/merge-strings-alternately/
/// </summary>
public class Problem
{
    public string MergeAlternately(string word1, string word2)
    {
        var sb = new StringBuilder();

        var i = 0;
        while (i < word1.Length && i < word2.Length)
        {
            sb.Append(word1[i])
                .Append(word2[i]);

            i++;
        }

        if(i < word1.Length)
           sb.Append(word1.AsSpan(i, word1.Length - i)); 
        
        if(i < word2.Length)
           sb.Append(word2.AsSpan(i, word2.Length - i)); 
        
        return sb.ToString();
    }
}