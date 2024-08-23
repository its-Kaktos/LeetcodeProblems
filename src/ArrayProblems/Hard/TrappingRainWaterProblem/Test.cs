using FluentAssertions;

namespace ArrayProblems.Hard.TrappingRainWaterProblem;

public class Test
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return [9, new[] { 4, 2, 0, 3, 2, 5 }];
        yield return [6, new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }];
        yield return [1, new[] { 4, 2, 3 }];
        yield return [1, new[] { 5, 4, 1, 2 }];
        yield return [83, new[] { 6, 4, 2, 0, 3, 2, 0, 3, 1, 4, 5, 3, 2, 7, 5, 3, 0, 1, 2, 1, 3, 4, 6, 8, 1, 3 }];
        yield return [0, new[] { 4, 4, 4, 7, 1, 0 }];
        yield return [7, new[] { 0, 7, 1, 4, 6 }];
        yield return [4, new[] { 9, 8, 2, 6 }];
        yield return [1, new[] { 4, 9, 4, 5, 3, 2 }];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int expected, int[] input)
    {
        var actual = _sut.Trap(input);

        actual.Should().Be(expected);
    }
}