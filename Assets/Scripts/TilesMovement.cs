using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesMovement : TruongMonoBehaviour
{
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
}