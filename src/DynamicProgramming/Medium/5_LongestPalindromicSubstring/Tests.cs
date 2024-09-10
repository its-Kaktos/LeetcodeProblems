using FluentAssertions;

namespace DynamicProgramming.Medium._5_LongestPalindromicSubstring;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return ["babad", "bab"];
        yield return ["cbbd", "bb"];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(string input, string expected)
    {
        var actual = _sut.LongestPalindrome(input);

        actual.Should().Be(expected);
    }
}