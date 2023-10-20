using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class CellSpawner : CellSpawnerAbstract
{
    protected override void SetPrefabNameInResource()
    {
        SetPrefabNameInResource(TruongPrefabName.CELL);
    }

    protected override void SetSpacing()
    {
        SetSpacing(0.05f);
    }


    protected override void Spawn()
    {
        var count = 0;
        for (int rowIndex = 0; rowIndex < this.CellsOnEdgeSquare; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < this.CellsOnEdgeSquare; columnIndex++)
            {
                var obj = SpawnDefaultObject();
                var cell = obj.GetComponent<Cell>();
                cell.SetData(new CellData()
                {
                    row = rowIndex,
                    column = columnIndex,
                });

                // cell.SetDebug();
                cell.SetName();
                cell.SetSizeModel(this.cellSize);
                cell.AddTile(count);
                cell.SetEmptyCell();

                count++;
            }
        }
    }

    protected override void SetupSquareLayout()
    {
        this.squareLayout = Holder.GetComponent<TruongSquareLayout>();
        squareLayout.SetUp(Cells.Instance.CellsPointEdgeSquare, this.CellsOnEdgeSquare, this.spacing);
    }

    [Button]
    public List<Cell> GetCellsCanSwaps()
    {
        var emptyCell = Cells.Instance.CellsSwaps.EmptyCell;
        List<Cell> cells = GetCells();
        var cell1 = cells.Find(t =>
            t.Data.column == emptyCell.Data.column &&
            t.Data.row + 1 == emptyCell.Data.row);
        var cell2 = cells.Find(t =>
            t.Data.column == emptyCell.Data.column &&
            t.Data.row - 1 == emptyCell.Data.row);
        var cell3 = cells.Find(t =>
            t.Data.column + 1 == emptyCell.Data.column &&
            t.Data.row == emptyCell.Data.row);
        var cell4 = cells.Find(t =>
            t.Data.column - 1 == emptyCell.Data.column &&
            t.Data.row == emptyCell.Data.row);
        return new List<Cell> { cell2, cell1, cell3, cell4 };
    }

    public List<Cell> GetCells()
    {
        var tiles = new List<Cell>();
        this.Holder.Items.ForEach(cell =>
        {
            if (!cell.gameObject.activeSelf) return;
            tiles.Add(cell.GetComponent<Cell>());
        });
        return tiles;
    }


    public Cell GetCell(int c, int r)
    {
        var cells = GetCells();
        var cell = cells.Find(t => t.Data.column == c && t.Data.row == r);
        return cell;
    }
}