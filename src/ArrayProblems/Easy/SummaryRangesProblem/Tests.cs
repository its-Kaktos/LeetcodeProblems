using FluentAssertions;

namespace ArrayProblems.Easy.SummaryRangesProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 0, 1, 2, 4, 5, 7 },
            new List<string>
            {
                "0->2", "4->5", "7"
            }
        ];
        yield return
        [
            new int[] { 0, 2, 3, 4, 6, 8, 9 },
            new List<string>
            {
                "0", "2->4", "6", "8->9"
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, List<string> expected)
    {
        var actual = _sut.SummaryRanges(input);

        actual.Should().BeEquivalentTo(expected);
    }
}