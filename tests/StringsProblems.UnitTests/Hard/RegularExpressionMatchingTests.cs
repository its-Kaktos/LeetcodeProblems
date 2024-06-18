using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
        yield return new object[] {"ab", ".*", true};
        yield return new object[] {"aab", "c*a*b", true};
        yield return new object[] {"mississippi", "mis*is*ip*.", true};
        yield return new object[] {"mississippi", "mis*is*p*.", false};
        yield return new object[] {"ab", ".*c", false};
        yield return new object[] {"aaa", "a*a", true};
        yield return new object[] {"aaa", "aaaa", false};
        yield return new object[] {"aaa", "ab*a*c*a", true};
        yield return new object[] {"a", "ab*a", false};
        yield return new object[] {"ab", ".*..", true};
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void Test(string input, string pattern, bool expected)
    {
        var actual = _sut.IsMatch(input, pattern);

        actual.Should().Be(expected);
    }
}