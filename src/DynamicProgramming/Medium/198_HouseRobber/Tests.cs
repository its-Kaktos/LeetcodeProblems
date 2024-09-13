using FluentAssertions;

namespace DynamicProgramming.Medium._198_HouseRobber;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1, 2, 3, 1 },
            4
        ];
        yield return
        [
            new int[] { 2, 7, 9, 3, 1 },
            12
        ];
        yield return
        [
            new int[] { 2, 1, 1, 2 },
            4
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.Rob(input);

        actual.Should().Be(expected);
    }
}