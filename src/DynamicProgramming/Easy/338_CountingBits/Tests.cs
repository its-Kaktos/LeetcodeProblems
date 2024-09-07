using FluentAssertions;

namespace DynamicProgramming.Easy._338_CountingBits;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            0,
            new int[] { 0 }
        ];
        yield return
        [
            1,
            new int[] { 0, 1 }
        ];
        yield return
        [
            2,
            new int[] { 0, 1, 1 }
        ];
        yield return
        [
            5,
            new int[] { 0, 1, 1, 2, 1, 2 }
        ];
        yield return
        [
            8,
            new int[] { 0, 1, 1, 2, 1, 2, 2, 3, 1 }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int input, int[] expected)
    {
        var actual = _sut.CountBits(input);

        actual.Should().BeEquivalentTo(expected);
    }
}