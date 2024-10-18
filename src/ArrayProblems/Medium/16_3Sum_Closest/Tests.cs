using FluentAssertions;

namespace ArrayProblems.Medium._16_3Sum_Closest;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { -1, 2, 1, -4 },
            1,
            2
        ];
        yield return
        [
            new int[] { 0, 0, 0 },
            1,
            0
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int target, int expected)
    {
        var actual = _sut.ThreeSumClosest(input, target);

        actual.Should().Be(expected);
    }
}