using FluentAssertions;

namespace DynamicProgramming.Medium._91_DecodeWays;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            "12",
            2
        ];
        yield return
        [
            "226",
            3
        ];
        yield return
        [
            "06",
            0
        ];
        yield return
        [
            "10",
            1
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(string input, int expected)
    {
        var actual = _sut.NumDecodings(input);

        actual.Should().Be(expected);
    }
}