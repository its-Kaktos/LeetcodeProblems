using FluentAssertions;

namespace HashMapProblems.Medium._128_Longest_Consecutive_Sequence;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 100, 4, 200, 1, 3, 2 },
            4,
        ];
        yield return
        [
            new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 },
            9,
        ];
        yield return
        [
            new int[] { 1, 2, 0, 1 },
            3,
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.LongestConsecutive(input);

        actual.Should().Be(expected);
    }
}