using FluentAssertions;

namespace ArrayProblems.Medium.JumpGame2Problem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return [2, new[] { 2, 3, 1, 1, 4 }];
        yield return [2, new[] { 2, 3, 0, 1, 4 }];
        yield return [0, new[] { 0 }];
        yield return [1, new[] { 2, 1 }];
        yield return [3, new[] { 1, 1, 1, 1 }];
        yield return [3, new[] { 1, 2, 1, 1, 1 }];
        yield return [2, new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 0 }];
        yield return [2, new[] { 2, 0, 2, 0, 1 }];
        yield return [3, new[] { 5, 9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0 }];
        yield return [-1, new[] { 5, 6, 4, 4, 6, 9, 4, 4, 7, 4, 4, 8, 2, 6, 8, 1, 5, 9, 6, 5, 2, 7, 9, 7, 9, 6, 9, 4, 1, 6, 8, 8, 4, 4, 2, 0, 3, 8, 5 }];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int expected, int[] input)
    {
        var actual = _sut.Jump(input);

        actual.Should().Be(expected);
    }
}