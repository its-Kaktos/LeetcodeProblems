using FluentAssertions;

namespace StringsProblems.Easy._13_Roman_To_Integer;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            "III",
            3
        ];
        yield return
        [
            "LVIII",
            58
        ];
        yield return
        [
            "MCMXCIV",
            1994
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(string input, int expected)
    {
        var actual = _sut.RomanToInt(input);

        actual.Should().Be(expected);
    }
}