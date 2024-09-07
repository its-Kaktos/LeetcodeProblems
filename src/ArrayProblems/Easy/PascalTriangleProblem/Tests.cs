using FluentAssertions;

namespace ArrayProblems.Easy.PascalTriangleProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            5,
            new List<IList<int>>
            {
                new List<int> { 1 },
                new List<int> { 1, 1 },
                new List<int> { 1, 2, 1 },
                new List<int> { 1, 3, 3, 1 },
                new List<int> { 1, 4, 6, 4, 1 },
            }
        ];
        yield return
        [
            1,
            new List<IList<int>>
            {
                new List<int> { 1 }
            }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(int input, IList<IList<int>> expected)
    {
        var actual = _sut.Generate(input);

        actual.Should().BeEquivalentTo(expected);
    }
}