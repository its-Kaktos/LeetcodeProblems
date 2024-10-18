namespace ArrayProblems.Medium._36_Valid_Sudoku;

public class Problem
{
    public bool IsValidSudoku(char[][] board)
    {
        var set = new HashSet<char>();

        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] is '.') continue;

                if (!set.Add(board[i][j])) return false;
            }

            set.Clear();
        }

        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                if (board[j][i] is '.') continue;

                if (!set.Add(board[j][i])) return false;
            }

            set.Clear();
        }

        var starts = new List<(int, int)>
        {
            (0, 0), (0, 3), (0, 6),
            (3, 0), (3, 3), (3, 6),
            (6, 0), (6, 3), (6, 6),
        };

        foreach (var (i, j) in starts)
        {
            set.Clear();

            for (var row = i; row < i + 3; row++)
            {
                for (var col = j; col < j + 3; col++)
                {
                    if (board[row][col] is '.') continue;

                    if (!set.Add(board[row][col])) return false;
                }
            }
        }

        return true;
    }
}