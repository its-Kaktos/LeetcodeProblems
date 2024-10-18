using FluentAssertions;

namespace ArrayProblems.Easy._561_Array_Partition;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 1,4,3,2 },
            4
        ];
        yield return
        [
            new int[] { 6,2,6,5,1,2 },
            9
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.ArrayPairSum(input);

        actual.Should().Be(expected);
    }
}