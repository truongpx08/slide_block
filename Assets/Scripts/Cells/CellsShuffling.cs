using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CellsShuffling : TruongMonoBehaviour
{
    public bool IsShuffling => isShuffling;
    [SerializeField] private bool isShuffling;

    [Button]
    public void Shuffling()
    {
        Shuffle();
        SetTilesTransformAfterShuffled();
    }

    private void Shuffle()
    {
        for (int i = 0; i < 3; i++)
        {
            ShuffleAllCells();
        }
    }

    [Button]
    private void ShuffleAllCells()
    {
        this.isShuffling = true;

        List<Cell> cells = Cells.Instance.CellsSpawner.GetCells();
        TruongUtils.ShuffleList<Cell>(cells);

        foreach (var cell in cells)
        {
            const int count = 100;
            var emptyCell = Cells.Instance.CellsSwaps.EmptyCell.Data;
            var swaps = Cells.Instance.CellsSwaps;

            for (int i = 0; i < count; i++)
            {
                if (emptyCell.row < cell.Data.row)
                    swaps.SwapsToDirection(TruongDirection.Bottom);
                else if (emptyCell.row > cell.Data.row)
                    swaps.SwapsToDirection(TruongDirection.Top);
                else if (emptyCell.column > cell.Data.column)
                    swaps.SwapsToDirection(TruongDirection.Left);
                else if (emptyCell.column < cell.Data.column)
                    swaps.SwapsToDirection(TruongDirection.Right);
                if (Cells.Instance.CellsSwaps.EmptyCell == cell) break;
            }
        }

        this.isShuffling = false;
    }


    [Button]
    private void SetTilesTransformAfterShuffled()
    {
        var cells = Cells.Instance.CellsSpawner.GetCells();
        cells.ForEach(c => c.SetTileTransformAfterShuffled());
    }
}