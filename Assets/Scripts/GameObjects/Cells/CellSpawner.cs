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
    public int Row => row;
    [SerializeField] private int column;
    [SerializeField] private float spacing;
    public float Spacing => spacing;
    [SerializeField] private float top;
    public float Top => top;
    [SerializeField] private float left;
    public float Left => left;
    [SerializeField] private int columnAndRow;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        this.spacing = 1.05f;
        SetSprites(null);
    }

    private void SetSpritesWithLevel(int level)
    {
        var spriteList = Resources
            .LoadAll<Sprite>(Path.Combine(TruongPath.GetSpriteInResourcePath(TruongFolderName.LEVEL), level.ToString()))
            .ToList();
        SetSprites(spriteList);
    }

    private void SetSprites(List<Sprite> spriteList)
    {
        this.sprites = spriteList;
    }

    protected override void SetPrefabNameInResource()
    {
        SetPrefabNameInResource(TruongPrefabName.CELL);
    }

    public void SpawnWithLevel(int level)
    {
        SetSpritesWithLevel(level);
        SetColumnAndRow(TruongUtils.GetSquareRoot(this.sprites.Count));
        Spawn(columnAndRow, columnAndRow);
    }

    private void SetColumnAndRow(int value)
    {
        this.columnAndRow = value;
    }

    [Button]
    public void Spawn(int rowNumber, int columnNumber)
    {
        this.row = rowNumber;
        this.column = columnNumber;
        InitVarToSetPosition();
        var count = 0;

        for (int r = 0; r < rowNumber; r++)
        {
            for (int c = 0; c < columnNumber; c++)
            {
                var obj = SpawnDefaultObject();
                var cell = obj.GetComponent<Cell>();
                cell.SetData(new CellData()
                {
                    row = r,
                    column = c,
                });

                // cell.SetDebug();
                cell.SetPosition(r, c);
                cell.AddTile(count);
                cell.SetName();
                cell.SetEmptyCell();

                count++;
            }
        }
    }

    private void InitVarToSetPosition()
    {
        float maxHeight = (this.row - 1) * this.spacing;
        float maxWidth = (this.column - 1) * this.spacing;
        this.top = maxHeight / 2;
        this.left = maxWidth / 2;
    }

    private void SetPositionCell(Transform obj, int r, int c)
    {
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
        this.Holder.Items.ForEach(i => tiles.Add(i.GetComponent<Cell>()));
        return tiles;
    }


    public Cell GetCell(int c, int r)
    {
        var cells = GetCells();
        var cell = cells.Find(t => t.Data.column == c && t.Data.row == r);
        return cell;
    }
}