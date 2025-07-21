using System.Collections.Generic;
using UnityEngine;

public class SlotBar : MonoBehaviour
{
    public int slotCount = 7;
    public List<PuzzlePiece> slots = new List<PuzzlePiece>();

    public delegate void MatchHandler(List<PuzzlePiece> matched);
    public event MatchHandler OnMatch;

    private void Awake()
    {
        for (int i = 0; i < slotCount; i++)
        {
            slots.Add(null);
        }
    }

    public bool AddPiece(PuzzlePiece piece)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = piece;
                CheckForMatch(i);
                return true;
            }
        }
        return false;
    }

    public void Swap(int indexA, int indexB)
    {
        if (indexA < 0 || indexA >= slotCount || indexB < 0 || indexB >= slotCount)
            return;
        var temp = slots[indexA];
        slots[indexA] = slots[indexB];
        slots[indexB] = temp;
        CheckForMatch(indexA);
        CheckForMatch(indexB);
    }

    private void CheckForMatch(int index)
    {
        var piece = slots[index];
        if (piece == null) return;

        int left = index;
        while (left > 0 && slots[left - 1] != null && slots[left - 1].Type == piece.Type)
            left--;

        int right = index;
        while (right < slotCount - 1 && slots[right + 1] != null && slots[right + 1].Type == piece.Type)
            right++;

        if (right - left + 1 >= 3)
        {
            List<PuzzlePiece> matched = new List<PuzzlePiece>();
            for (int i = left; i <= right; i++)
            {
                matched.Add(slots[i]);
                slots[i] = null;
            }
            OnMatch?.Invoke(matched);
        }
    }
}
