using System.Text.Json;
using FluentAssertions;

namespace ArrayProblems.Medium.PermutationsProblem;

public class Tests
{
    private readonly Problem _sut = new();

    public static IEnumerable<object[]> Data_Test()
    {
        yield return
        [
            new List<IList<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 3, 2 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 3, 1 },
                new List<int> { 3, 1, 2 },
                new List<int> { 3, 2, 1 }
            },
            new[] { 1, 2, 3 }
        ];
        yield return
        [
            new List<IList<int>>
            {
                new List<int> { 0, 1 },
                new List<int> { 1, 0 }
            },
            new[] { 0, 1 }
        ];
        yield return
        [
            new List<IList<int>>
            {
                new List<int> { 1 },
            },
            new[] { 1 }
        ];
    }

    [Theory]
    [MemberData(nameof(Data_Test))]
    public void TestResult(IList<IList<int>> expected, int[] input)
    {
        var actual = _sut.Permute(input);

        if (actual.Count != expected.Count)
        {
            Assert.Fail($"Expected count of {expected.Count} but this does not follow {JsonSerializer.Serialize(actual)}");
        }

        var count = expected[0].Count;
        foreach (var e in expected)
        {
            var isEqual = false;
            foreach (var a in actual)
            {
                if (a.Count != e.Count) continue;

                var itemsEqual = true;
                for (var i = 0; i < e.Count; i++)
                {
                    if (a[i] != e[i])
                    {
                        itemsEqual = false;
                        break;
                    }
                }

                if (!itemsEqual) continue;

                isEqual = true;
                break;
            }

            if (!isEqual)
            {
                var json = JsonSerializer.Serialize(actual);
                Assert.Fail($"Not a valid response {json}");
            }
        }
    }
}