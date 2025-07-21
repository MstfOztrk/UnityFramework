using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public PuzzleBoard board;
    public SlotBar slotBar;

    private int moveCount = 30;

    private void OnEnable()
    {
        slotBar.OnMatch += HandleMatch;
    }

    private void OnDisable()
    {
        slotBar.OnMatch -= HandleMatch;
    }

    public void SelectPiece(Vector2Int gridPos)
    {
        if (moveCount <= 0) return;
        var piece = board.PickPiece(gridPos);
        if (piece != null && slotBar.AddPiece(piece))
        {
            moveCount--;
        }
    }

    public void Swap(int indexA, int indexB)
    {
        if (moveCount <= 0) return;
        slotBar.Swap(indexA, indexB);
        moveCount--;
    }

    private void HandleMatch(System.Collections.Generic.List<PuzzlePiece> matched)
    {
        board.ShiftRowsDown();
    }
}
