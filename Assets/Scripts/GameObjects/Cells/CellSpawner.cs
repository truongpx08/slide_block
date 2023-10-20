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
    [SerializeField] private int cellsOnEdgeSquare;
    [SerializeField] private float spacing;
    [SerializeField] private TruongSquareLayout squareLayout;
    [SerializeField] private float cellSize;
    public int CellsOnEdgeSquare => cellsOnEdgeSquare;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        SetSprites(null);
        this.spacing = 0.05f;
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
        SetCellsOnEdgeSquare(TruongUtils.GetSquareRoot(this.sprites.Count));
        SetupSquareLayout();
        SetCellSize();
        Spawn();
        SetPositionCells();
    }

    private void SetPositionCells()
    {
        this.squareLayout.SetPositionChildren();
    }

    private void SetCellSize()
    {
        this.cellSize = this.squareLayout.CellSize;
    }

    private void SetupSquareLayout()
    {
        this.squareLayout = Holder.GetComponent<TruongSquareLayout>();
        squareLayout.SetUp(Cells.Instance.CellsPointEdgeSquare, this.CellsOnEdgeSquare, this.spacing);
    }

    private void SetCellsOnEdgeSquare(int value)
    {
        this.cellsOnEdgeSquare = value;
    }

    [Button]
    public void Spawn()
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