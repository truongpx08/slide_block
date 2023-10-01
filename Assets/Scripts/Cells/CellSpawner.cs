using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class CellSpawner : TruongSpawner
{
    [SerializeField] private List<Sprite> sprites;
    public List<Sprite> Sprites => sprites;
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private float spacing;
    [SerializeField] private float top;
    [SerializeField] private float left;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        this.spacing = 1.05f;
        sprites = Resources.LoadAll<Sprite>(TruongPath.GetSpriteInResourcePath("char")).ToList();
    }

    protected override void SetPrefabNameInResource()
    {
        SetPrefabNameInResource(TruongPrefabName.CELL);
    }

    [Button]
    public void Spawn(int row, int column)
    {
        this.row = row;
        this.column = column;
        InitVarToSetPosition();
        var count = 0;

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < column; c++)
            {
                var obj = SpawnDefaultObject();
                SetPosition(obj, r, c);
                var cell = obj.GetComponent<Cell>();
                cell.SetData(new CellData()
                {
                    row = r,
                    column = c,
                });
                // cell.SetDebug();
                cell.AddTile(count);
                cell.SetName();
                SetEmptyCell(cell);

                count++;
            }
        }
    }


    private void SetEmptyCell(Cell cell)
    {
        if (cell.Data.column != 0 || cell.Data.row != this.row - 1) return;
        Cells.Instance.CellsSwaps.SetEmptyCell(cell);

        cell.DisableDebug();
        var tile = cell.TileSpawner.Holder.GetDefaultOrFirstItem().GetComponent<Tile>();
        tile.SetEmpty();
        tile.DisableDebug();
    }

    private void InitVarToSetPosition()
    {
        float maxHeight = (this.row - 1) * this.spacing;
        float maxWidth = (this.column - 1) * this.spacing;
        this.top = maxHeight / 2;
        this.left = maxWidth / 2;
    }

    private void SetPosition(Transform obj, int r, int c)
    {
        obj.transform.position = new Vector3(c * spacing - left, r * -spacing + top, 0);
    }

    [Button]
    public List<Cell> GetCellsCanSwaps()
    {
        var emptyCell = FindObjectOfType<CellsSwaps>().EmptyCell;
        List<Cell> tiles = new List<Cell>();
        this.Holder.Items.ForEach(i => tiles.Add(i.GetComponent<Cell>()));
        var cell1 = tiles.Find(t =>
            t.Data.column == emptyCell.Data.column &&
            t.Data.row + 1 == emptyCell.Data.row);
        var cell2 = tiles.Find(t =>
            t.Data.column == emptyCell.Data.column &&
            t.Data.row - 1 == emptyCell.Data.row);
        var cell3 = tiles.Find(t =>
            t.Data.column + 1 == emptyCell.Data.column &&
            t.Data.row == emptyCell.Data.row);
        var cell4 = tiles.Find(t =>
            t.Data.column - 1 == emptyCell.Data.column &&
            t.Data.row == emptyCell.Data.row);
        return new List<Cell> { cell2, cell1, cell3, cell4 };
    }
}