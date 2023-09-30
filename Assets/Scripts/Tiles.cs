using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : TruongMonoBehaviour
{
    [SerializeField] private TileSpawner tilesSpawner;
    public TileSpawner TilesSpawner => tilesSpawner;
    [SerializeField] private TilesMovement tilesMovement;
    public TilesMovement TilesMovement => tilesMovement;
    [SerializeField] private TilesShuffle tilesShuffle;
    public TilesShuffle TilesShuffle => tilesShuffle;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTileSpawner();
        LoadTileMovement();
        LoadTilesShuffle();
    }

    private void LoadTilesShuffle()
    {
        this.tilesShuffle = GetComponentInChildren<TilesShuffle>();
    }

    private void LoadTileMovement()
    {
        this.tilesMovement = GetComponentInChildren<TilesMovement>();
    }

    private void LoadTileSpawner()
    {
        this.tilesSpawner = GetComponentInChildren<TileSpawner>();
    }
}