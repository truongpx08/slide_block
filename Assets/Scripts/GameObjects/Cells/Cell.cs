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

    CellSpawner CellSpawner => Cells.Instance.CellSpawner;

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
            row = this.data.row,
            column = this.data.column,
            id = count,
        });
        // tile.SetDebug();
        newTile.SetName();
        newTile.SetModel();
        SetTile(newTile);
    }


    public void SetDebug()
    {
        this.debugPos.text = $"C {this.Data.column} {this.Data.row}";
    }

    public void SetName()
    {
        this.name = "Cell " + Data.column + " " + Data.row;
    }

    public void SetTile(Tile value)
    {
        this.tile = value;
        SetParentOfTile();
    }

    public void SetParentOfTile()
    {
        this.Tile.SetParent(this);
    }

    [Button]
    int GetInstanceIda()
    {
        return this.gameObject.GetInstanceID();
    }

    [Button]
    public void SetEmptyCell()
    {
        if (Data.column != 0 || Data.row != Cells.Instance.CellSpawner.Row - 1) return;
        Tile.SetEmpty();
        Tile.DisableDebug();
        Cells.Instance.CellsSwaps.SetEmptyCell(this);
    }


    public void SetPosition(int row, int column)
    {
        float spacing = CellSpawner.Spacing;
        this.transform.position =
            new Vector3(column * spacing - CellSpawner.Left, row * -spacing + CellSpawner.Top, 0);
    }
}