using FluentAssertions;
using StringsProblems.Medium;

namespace StringsProblems.UnitTests.Medium;

public class StringToIntegerAtoiTests
{
    private StringToIntegerAtoi _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return ["42", 42];
        yield return ["   -042", -42];
        yield return ["   +042", 42];
        yield return ["   +-042", 0];
        yield return ["   +-042", 0];
        yield return ["1337c0d32", 1337];
        yield return ["swd1337c0d32", 0];
        yield return ["0-1", 0];
        yield return ["words and 987", 0];
        yield return ["20000000000000", int.MaxValue];
        yield return ["-20000000000000", int.MinValue];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    
    public void Test(string input, int expected)
    {
        var actual = _sut.MyAtoi(input);

        actual.Should().Be(expected);
    }
}