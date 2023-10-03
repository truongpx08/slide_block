using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CellsShuffling : TruongMonoBehaviour
{
    [SerializeField] private int amount;
    public bool IsShuffling => isShuffling;
    [SerializeField] private bool isShuffling;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        this.amount = 1000;
    }

    [Button]
    public void Shuffling()
    {
        Shuffle();
        SetTileTransformAfterShuffled();
    }

    [Button]
    private void Shuffle()
    {
        this.isShuffling = true;
        for (int i = 0; i < this.amount; i++)
        {
            Cells.Instance.CellsSwaps.Swaps(GetCell());
        }

        this.isShuffling = false;
    }

    [Button]
    private void SetTileTransformAfterShuffled()
    {
        var cells = Cells.Instance.CellsSpawner.GetCells();
        cells.ForEach(c => c.SetTransformAfterShuffled());
    }


    private Cell GetCell()
    {
        var cellsCanSwaps = Cells.Instance.CellsSpawner.GetCellsCanSwaps();
        cellsCanSwaps.RemoveAll(item => item == null);
        return cellsCanSwaps[Random.Range(0, cellsCanSwaps.Count - 1)];
    }
}