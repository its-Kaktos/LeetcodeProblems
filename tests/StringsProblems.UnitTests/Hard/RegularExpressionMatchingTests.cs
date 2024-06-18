using FluentAssertions;
using StringsProblems.Hard;

namespace StringsProblems.UnitTests.Hard;

public class RegularExpressionMatchingTests
{
    private RegularExpressionMatching _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return ["aa", "a", false];
        yield return ["aa", "a*", true];
        yield return ["aa", ".*", true];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void Test(string input, string pattern, bool expected)
    {
        var actual = _sut.IsMatch(input, pattern);

        actual.Should().Be(expected);
    }
}