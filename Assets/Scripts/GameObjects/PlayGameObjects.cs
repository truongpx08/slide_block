using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameObjects : TruongSingleton<PlayGameObjects>
{
    [SerializeField] private Cells goCells;
    public Cells GoCells => goCells;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGoTiles();
    }

    private void LoadGoTiles()
    {
        this.goCells = GetComponentInChildren<Cells>();
    }

    protected override void SetDontDestroyOnLoad()
    {
        SetDontDestroyOnLoad(false);
    }
}