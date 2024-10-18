using FluentAssertions;

namespace ArrayProblems.Easy._643_Maximum_Average_Subarray_1;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1, 12, -5, -6, 50, 3 },
            4,
            12.75000
        ];
        yield return
        [
            new int[] { 5 },
            1,
            5.00000
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int k, double expected)
    {
        var actual = _sut.FindMaxAverage(input, k);

        actual.Should().Be(expected);
    }
}