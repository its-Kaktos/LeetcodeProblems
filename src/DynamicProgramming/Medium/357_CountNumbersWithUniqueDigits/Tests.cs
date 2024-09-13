using FluentAssertions;

namespace DynamicProgramming.Medium._357_CountNumbersWithUniqueDigits;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            2,
            91
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int input, int expected)
    {
        var actual = _sut.CountNumbersWithUniqueDigits(input);

        actual.Should().Be(expected);
    }
}