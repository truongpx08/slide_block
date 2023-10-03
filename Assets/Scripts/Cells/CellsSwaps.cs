using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CellsSwaps : TruongMonoBehaviour
{
    [SerializeField] private Cell emptyCell;
    public Cell EmptyCell => this.emptyCell;

    public void SetEmptyCell(Cell value)
    {
        this.emptyCell = value;
    }

    [SerializeField] private Cells cells;
    public Cells Cells => cells;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTiles();
    }

    private void LoadTiles()
    {
        this.cells = GetComponentInParent<Cells>();
    }

    public void Swapping(TruongDragDirection dragDirection)
    {
        var cellsCanSwaps = Cells.CellsSpawner.GetCellsCanSwaps();
        cellsCanSwaps.RemoveAll(item => item == null);

        Cell cellCanSwaps = null;
        switch (dragDirection)
        {
            case TruongDragDirection.None:
                break;
            case TruongDragDirection.Top:
                cellCanSwaps = cellsCanSwaps.Find(t => t.Data.row > this.EmptyCell.Data.row);
                break;
            case TruongDragDirection.Bottom:
                cellCanSwaps = cellsCanSwaps.Find(t => t.Data.row < this.EmptyCell.Data.row);
                break;
            case TruongDragDirection.Left:
                cellCanSwaps = cellsCanSwaps.Find(t => t.Data.column > this.EmptyCell.Data.column);
                break;
            case TruongDragDirection.Right:
                cellCanSwaps = cellsCanSwaps.Find(t => t.Data.column < this.EmptyCell.Data.column);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dragDirection), dragDirection, null);
        }

        Swaps(cellCanSwaps);
    }

    [Button]
    public void Swaps(Cell cellCanSwaps)
    {
        if (cellCanSwaps == null) return;
        Debug.Log($"Swapping {cellCanSwaps.name} to {EmptyCell.name}");

        cellCanSwaps.MoveTileToCell(EmptyCell);
        this.EmptyCell.MoveTileToCell(cellCanSwaps);

        var tile = cellCanSwaps.Tile;
        cellCanSwaps.SetTile(EmptyCell.Tile);
        this.EmptyCell.SetTile(tile);

        SetEmptyCell(cellCanSwaps);
    }
}