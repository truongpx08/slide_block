using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CellsSwaps : TruongMonoBehaviour
{
    [SerializeField] private Cell emptyCell;
    public Cell EmptyCell => this.emptyCell;

    private static Cells Cells => Cells.Instance;

    public void SetEmptyCell(Cell value)
    {
        this.emptyCell = value;
    }

    public void SwapsWithInput(TruongDirection direction)
    {
        switch (direction)
        {
            case TruongDirection.None:
                break;
            case TruongDirection.Top:
                SwapsToDirection(TruongDirection.Bottom);
                break;
            case TruongDirection.Bottom:
                SwapsToDirection(TruongDirection.Top);
                break;
            case TruongDirection.Left:
                SwapsToDirection(TruongDirection.Right);
                break;
            case TruongDirection.Right:
                SwapsToDirection(TruongDirection.Left);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }


    [Button]
    public void SwapsToDirection(TruongDirection direction)
    {
        Cell cell = null;
        switch (direction)
        {
            case TruongDirection.None:
                break;
            case TruongDirection.Top:
                cell = Cells.CellSpawner.GetCells().Find(c =>
                    c.Data.column == EmptyCell.Data.column && c.Data.row + 1 == EmptyCell.Data.row);
                break;
            case TruongDirection.Bottom:
                cell = Cells.CellSpawner.GetCells().Find(c =>
                    c.Data.column == EmptyCell.Data.column && c.Data.row - 1 == EmptyCell.Data.row);
                break;
            case TruongDirection.Left:
                cell = Cells.CellSpawner.GetCells().Find(c =>
                    c.Data.column + 1 == EmptyCell.Data.column && c.Data.row == EmptyCell.Data.row);
                break;
            case TruongDirection.Right:
                cell = Cells.CellSpawner.GetCells().Find(c =>
                    c.Data.column - 1 == EmptyCell.Data.column && c.Data.row == EmptyCell.Data.row);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        Swaps(cell);
    }

    [Button]
    public void Swaps(Cell cellCanSwaps)
    {
        if (cellCanSwaps == null) return;
        Debug.Log($"Swapping {cellCanSwaps.name} to {EmptyCell.name}");

        Tile tileTemp = cellCanSwaps.Tile;
        cellCanSwaps.SetTile(EmptyCell.Tile);
        this.EmptyCell.SetTile(tileTemp);
        
        SetEmptyCell(cellCanSwaps);
    }
}