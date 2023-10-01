using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TileSpawner : TruongSpawner
{
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private float spacing;
    [SerializeField] private float top;
    [SerializeField] private float left;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        this.spacing = 1.05f;
    }

    protected override void SetPrefabNameInResource()
    {
        SetPrefabNameInResource(TruongPrefabName.TILE);
    }

    [Button]
    public void Spawn(int row, int column)
    {
        this.row = row;
        this.column = column;
        InitVarToSetPosition();

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < column; c++)
            {
                var obj = SpawnDefaultObject();
                SetPosition(obj, r, c);
                var tile = obj.GetComponent<Tile>();
                tile.SetData(new TileData()
                {
                    currentRow = r,
                    currentColumn = c,
                    originRow = r,
                    originColumn = c,
                });
                tile.SetDebug();
                obj.name = c.ToString() + " " + r.ToString();

                SetEmptyTile(r, c, tile);
            }
        }
    }

    private void SetEmptyTile(int r, int c, Tile tile)
    {
        if (c != 2 || r != 2) return;
        tile.SetEmpty();
        GetComponentInBro<TilesShuffle>().SetEmptyTile(tile);
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
        obj.transform.position = new Vector3(c * spacing - left, r * spacing - top, 0);
    }

    [Button]
    public List<Tile> GetTilesCanMove()
    {
        var emptyTile = GetComponentInBro<TilesShuffle>().EmptyTile;
        List<Tile> tiles = new List<Tile>();
        this.Holder.Items.ForEach(i => tiles.Add(i.GetComponent<Tile>()));
        var tile1 = tiles.Find(t =>
            t.Data.currentColumn == emptyTile.Data.currentColumn &&
            t.Data.currentRow + 1 == emptyTile.Data.currentRow);
        var tile2 = tiles.Find(t =>
            t.Data.currentColumn == emptyTile.Data.currentColumn &&
            t.Data.currentRow - 1 == emptyTile.Data.currentRow);
        var tile3 = tiles.Find(t =>
            t.Data.currentColumn + 1 == emptyTile.Data.currentColumn &&
            t.Data.currentRow == emptyTile.Data.currentRow);
        var tile4 = tiles.Find(t =>
            t.Data.currentColumn - 1 == emptyTile.Data.currentColumn &&
            t.Data.currentRow == emptyTile.Data.currentRow);
        return new List<Tile> { tile1, tile2, tile3, tile4 };
    }
}