using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSwaps : TruongMonoBehaviour
{
    [SerializeField] private Tile emptyTile;
    public Tile EmptyTile => this.emptyTile;

    public void SetEmptyTile(Tile tile)
    {
        this.emptyTile = tile;
    }

    [SerializeField] private Tiles tiles;
    public Tiles Tiles => tiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTiles();
    }

    private void LoadTiles()
    {
        this.tiles = GetComponentInParent<Tiles>();
    }

    public void CalculateTileCanSwaps(TruongDragDirection dragDirection)
    {
        var tilesCanSwaps = Tiles.TilesSpawner.GetTilesCanSwaps();
        Tile tileCanSwaps = null;
        switch (dragDirection)
        {
            case TruongDragDirection.None:
                break;
            case TruongDragDirection.Top:
                tileCanSwaps = tilesCanSwaps.Find(t => t.Data.currentRow < this.EmptyTile.Data.currentRow);
                break;
            case TruongDragDirection.Bottom:
                tileCanSwaps = tilesCanSwaps.Find(t => t.Data.currentRow > this.EmptyTile.Data.currentRow);
                break;
            case TruongDragDirection.Left:
                tileCanSwaps = tilesCanSwaps.Find(t => t.Data.currentColumn > this.EmptyTile.Data.currentColumn);
                break;
            case TruongDragDirection.Right:
                tileCanSwaps = tilesCanSwaps.Find(t => t.Data.currentColumn < this.EmptyTile.Data.currentColumn);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dragDirection), dragDirection, null);
        }

        Debug.Log($"Swapping {tileCanSwaps.name}");
        SwapsWithEmptyTile(tileCanSwaps);
    }

    private void SwapsWithEmptyTile(Tile tileCanSwaps)
    {
        var tileCanSwapsT = tileCanSwaps.transform;
        var emptyTileT = this.emptyTile.transform;
        (tileCanSwapsT.position, emptyTileT.position) = (emptyTileT.position, tileCanSwapsT.position);
        SetEmptyTile(tileCanSwaps);
    }
}