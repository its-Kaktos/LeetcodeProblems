using FluentAssertions;

namespace DynamicProgramming.Easy._509_FibonacciNumber;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            2,
            1
        ];
        yield return
        [
            3,
            2
        ];
        yield return
        [
            4,
            3
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int input, int expected)
    {
        var actual = _sut.Fib(input);

        actual.Should().Be(expected);
    }
}