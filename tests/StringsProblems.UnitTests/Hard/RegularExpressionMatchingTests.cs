using FluentAssertions;
using StringsProblems.Hard;

namespace StringsProblems.UnitTests.Hard;

public class RegularExpressionMatchingTests
{
    private readonly RegularExpressionMatching _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return new object[] {"aa", "a", false};
        yield return new object[] {"aa", "a*", true};
        yield return new object[] {"aa", ".*", true};
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void Test(string input, string pattern, bool expected)
    {
        var actual = _sut.IsMatch(input, pattern);

        actual.Should().Be(expected);
    }
}