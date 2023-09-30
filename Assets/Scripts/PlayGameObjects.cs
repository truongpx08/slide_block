using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameObjects : TruongSingleton<PlayGameObjects>
{
    [SerializeField] private Tiles goTiles;
    public Tiles GoTiles => goTiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGoTiles();
    }

    private void LoadGoTiles()
    {
        this.goTiles = GetComponentInChildren<Tiles>();
    }

    protected override void SetDontDestroyOnLoad()
    {
        SetDontDestroyOnLoad(false);
    }
}