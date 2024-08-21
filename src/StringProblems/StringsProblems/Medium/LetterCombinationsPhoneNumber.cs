using System.Collections.Immutable;
using System.Text;

namespace StringsProblems.Medium;

/// <summary>
/// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
/// </summary>
public class LetterCombinationsPhoneNumber
{
    private static readonly Dictionary<char, string> _map = new()
    {
        { '2', "abc" },
        { '3', "def" },
        { '4', "ghi" },
        { '5', "jkl" },
        { '6', "mno" },
        { '7', "pqrs" },
        { '8', "tuv" },
        { '9', "wxyz" }
    };

    private readonly IList<string> _r = new List<string>();

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length > 0) AddLetterCombinations(digits, 0, "");

        return _r;
    }

    private void AddLetterCombinations(string digits, int pos, string prepend)
    {
        if (pos == digits.Length)
        {
            _r.Add(prepend);

            return;
        }

        foreach (var c in _map[digits[pos]])
        {
            AddLetterCombinations(digits, pos + 1, prepend + c);
        }
    }
}