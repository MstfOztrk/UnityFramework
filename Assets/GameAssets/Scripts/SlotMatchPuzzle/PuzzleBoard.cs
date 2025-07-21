using UnityEngine;

public class PuzzleBoard : MonoBehaviour
{
    public int rows = 6;
    public int columns = 6;
    public PuzzlePiece[,] grid;

    private void Awake()
    {
        grid = new PuzzlePiece[rows, columns];
        FillGrid();
    }

    public void FillGrid()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                grid[r, c] = CreateRandomPiece(r, c);
            }
        }
    }

    private PuzzlePiece CreateRandomPiece(int r, int c)
    {
        PuzzlePiece piece = new PuzzlePiece();
        piece.Type = (PieceType)Random.Range(0, System.Enum.GetValues(typeof(PieceType)).Length);
        piece.GridPosition = new Vector2Int(r, c);
        return piece;
    }

    public PuzzlePiece PickPiece(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x >= rows || pos.y < 0 || pos.y >= columns)
            return null;
        var piece = grid[pos.x, pos.y];
        grid[pos.x, pos.y] = null;
        return piece;
    }

    public void ShiftRowsDown()
    {
        for (int r = rows - 1; r > 0; r--)
        {
            for (int c = 0; c < columns; c++)
            {
                grid[r, c] = grid[r - 1, c];
                if (grid[r, c] != null)
                {
                    grid[r, c].GridPosition = new Vector2Int(r, c);
                }
            }
        }

        for (int c = 0; c < columns; c++)
        {
            grid[0, c] = CreateRandomPiece(0, c);
        }
    }
}
