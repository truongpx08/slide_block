using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class Cell : TruongMonoBehaviour
{
    [SerializeField] private TileSpawner tileSpawner;
    public TileSpawner TileSpawner => tileSpawner;
    [SerializeField] private TextMeshPro debugPos;

    [SerializeField] private CellData data;
    public CellData Data => data;

    public Tile Tile => tile;
    [SerializeField] private Tile tile;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTileSpawner();
        LoadPos();
    }

    private void LoadTileSpawner()
    {
        this.tileSpawner = GetComponentInChildren<TileSpawner>();
    }

    private void LoadPos()
    {
        this.debugPos = transform.Find("Debug").Find("Pos").GetComponent<TextMeshPro>();
    }

    public void SetData(CellData cellData)
    {
        this.data = cellData;
    }

    public void AddTile(int count)
    {
        var go = this.TileSpawner.SpawnDefaultObject();
        var newTile = go.GetComponent<Tile>();
        newTile.SetData(new TileData
        {
            currentRow = this.data.row,
            currentColumn = this.data.column,
            originRow = this.data.row,
            originColumn = this.data.column,
            id = count,
        });
        // tile.SetDebug();
        newTile.SetName();
        newTile.SetModel();

        this.tile = newTile;
    }


    public void SetDebug()
    {
        this.debugPos.text = $"C {this.Data.column} {this.Data.row}";
    }

    public void SetName()
    {
        this.name = "Cell " + Data.column + " " + Data.row;
    }

    private void SetEmptyTile(Tile t)
    {
        t.SetEmpty();
    }

    public void SetTile(Tile value)
    {
        this.tile = value;
    }

    public void MoveTileToCell(Cell cell)
    {
        this.Tile.MoveToCell(cell);
    }

    public void SetTransformAfterShuffled()
    {
        this.Tile.SetParentToCell(this);
    }
}