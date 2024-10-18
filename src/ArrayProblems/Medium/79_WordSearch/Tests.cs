using FluentAssertions;

namespace ArrayProblems.Medium._79_WordSearch;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new char[][]
            {
                ['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']
            },
            "ABCCED",
            true
        ];
        yield return
        [
            new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            },
            "SEE",
            true
        ];
        yield return
        [
            new char[][]
            {
                ['A', 'B', 'C', 'E'],
                ['S', 'F', 'C', 'S'],
                ['A', 'D', 'E', 'E']
            },
            "ABCB",
            false
        ];
        yield return
        [
            new char[][]
            {
                ['a']
            },
            "a",
            true
        ];
        yield return
        [
            new char[][]
            {
                ['A', 'A', 'A', 'A', 'A', 'A'], 
                ['A', 'A', 'A', 'B', 'A', 'A'],
                ['A', 'A', 'A', 'A', 'A', 'A'],
                ['A', 'A', 'A', 'A', 'A', 'A'],
                ['A', 'A', 'A', 'A', 'A', 'A'],
                ['A', 'A', 'A', 'A', 'A', 'A']
            },
            "AB",
            true
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(char[][] input, string word, bool expected)
    {
        var actual = _sut.Exist(input, word);

        actual.Should().Be(expected);
    }
}