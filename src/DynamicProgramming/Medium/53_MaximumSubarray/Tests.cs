using FluentAssertions;

namespace DynamicProgramming.Medium._53_MaximumSubarray;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            // The subarray [1] has the largest sum 1.
            new int[] { 1 },
            1
        ];
        yield return
        [
            // The subarray [4,-1,2,1] has the largest sum 6
            new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 },
            6
        ];
        yield return
        [
            // The subarray [5,4,-1,7,8] has the largest sum 23.
            new int[] { 5, 4, -1, 7, 8 },
            23
        ];
        yield return
        [
            // The subarray [-1] has the largest sum -1.
            new int[] { -1, -2, -3, -4},
            -1
        ];
        yield return
        [
            // The subarray [-1] has the largest sum -1.
            new int[] { -2, -1, -3, -4},
            -1
        ];
        yield return
        [
            // The subarray [3] has the largest sum 3.
            new int[] { -2, -1, 3, -4},
            3
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.MaxSubArray(input);

        actual.Should().Be(expected);
    }
}