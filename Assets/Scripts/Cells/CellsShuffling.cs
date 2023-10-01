using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CellsShuffling : TruongMonoBehaviour
{
    [SerializeField] private int amount;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        this.amount = 1000;
    }

    [Button]
    public void Shuffle()
    {
        for (int i = 0; i < this.amount; i++)
        {
            Cells.Instance.CellsSwaps.Swaps(GetCell());
        }
    }

    private Cell GetCell()
    {
        var cellsCanSwaps = Cells.Instance.CellsSpawner.GetCellsCanSwaps();
        cellsCanSwaps.RemoveAll(item => item == null);

        var cell = cellsCanSwaps.Find(c => !c.Data.isTileSwapped);
        return cell != null ? cell : cellsCanSwaps[Random.Range(0, cellsCanSwaps.Count - 1)];
    }
}