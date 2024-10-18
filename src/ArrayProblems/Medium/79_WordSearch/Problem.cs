namespace ArrayProblems.Medium._79_WordSearch;

/// <summary>
///  https://leetcode.com/problems/spiral-matrix/description/?envType=problem-list-v2&envId=array&difficulty=MEDIUM
/// </summary>
public class Problem
{
    public bool Exist(char[][] boards, string word)
    {
        var rowSize = boards.Length;
        var colSize = boards[0].Length;
        var lastMove = new HashSet<(int, int)>();
        for (var row = 0; row < rowSize; row++)
        {
            for (var col = 0; col < colSize; col++)
            {
                if (boards[row][col] == word[0] && ExistInternal(0, row, col)) return true;
            }
        }

        return false;

        bool ExistInternal(int wordIndex, int row, int col)
        {
            if (wordIndex > word.Length - 1) return true;
            if (row < 0 || col < 0 ||
                row >= rowSize || col >= colSize ||
                lastMove.Contains((row, col)) ||
                word[wordIndex] != boards[row][col]) return false;

            lastMove.Add((row, col));

            var result = ExistInternal(wordIndex + 1, row, col - 1) ||
                         ExistInternal(wordIndex + 1, row, col + 1) ||
                         ExistInternal(wordIndex + 1, row + 1, col) ||
                         ExistInternal(wordIndex + 1, row - 1, col);

            lastMove.Remove((row, col));
            return result;
        }
    }
}