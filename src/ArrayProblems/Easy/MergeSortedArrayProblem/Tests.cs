using FluentAssertions;

namespace ArrayProblems.Easy.MergeSortedArrayProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1, 2, 3, 0, 0, 0 },
            3,
            new int[] { 2, 5, 6 },
            3,
            new int[] { 1, 2, 2, 3, 5, 6 }
        ];
        yield return
        [
            new int[] { 1 },
            1,
            new int[] { },
            0,
            new int[] { 1 }
        ];
        yield return
        [
            new int[] { 0 },
            0,
            new int[] { 1 },
            1,
            new int[] { 1 }
        ];
        yield return
        [
            new int[] { 0, 0, 0, 0, 0 },
            0,
            new int[] { 1, 2, 3, 4, 5 },
            5,
            new int[] { 1, 2, 3, 4, 5 }
        ];
        yield return
        [
            new int[] { 4, 5, 6, 0, 0, 0 },
            3,
            new int[] { 1, 2, 3 },
            3,
            new int[] { 1, 2, 3, 4, 5, 6 }
        ];
        yield return
        [
            new int[] { 4, 0, 0, 0, 0, 0 },
            1,
            new int[] { 1, 2, 3, 5, 6 },
            5,
            new int[] { 1, 2, 3, 4, 5, 6 }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        _sut.Merge(nums1, m, nums2, n);

        nums1.Should().Equal(expected);
    }
}