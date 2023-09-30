using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesShuffle : MonoBehaviour
{
    [SerializeField] private Tile emptyTile;
    public Tile EmptyTile => this.emptyTile;

    public void SetEmptyTile(Tile tile)
    {
        this.emptyTile = tile;
    }
}