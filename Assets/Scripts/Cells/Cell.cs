using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : TruongMonoBehaviour
{
    [SerializeField] private TileSpawner tileSpawner;
    public TileSpawner TileSpawner => tileSpawner;
    [SerializeField] private TextMeshPro debugPos;

    [SerializeField] private CellData data;
    public CellData Data => data;

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
        var tile = go.GetComponent<Tile>();
        tile.SetData(new TileData
        {
            currentRow = this.data.row,
            currentColumn = this.data.column,
            originRow = this.data.row,
            originColumn = this.data.column,
            id = count,
        });
        // tile.SetDebug();
        tile.SetName();
        tile.SetModel();
    }

    private void SetEmptyTile(Tile tile)
    {
        tile.SetEmpty();
    }

    public void SetDebug()
    {
        this.debugPos.text = $"C {this.Data.column} {this.Data.row}";
    }

    public void SetName()
    {
        this.name = "Cell " + Data.column + " " + Data.row;
    }

    public void DisableDebug()
    {
        this.debugPos.gameObject.SetActive(false);
    }
}