using FluentAssertions;

namespace DynamicProgramming.Easy._121_BestTimeToBuyAndSellStock;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new int[] { 7, 1, 5, 3, 6, 4 },
            5
        ];
        yield return
        [
            new int[] { 7,6,4,3,1 },
            0
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int[] input, int expected)
    {
        var actual = _sut.MaxProfit(input);

        actual.Should().Be(expected);
    }
}