using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : TruongSingleton<Cells>
{
    [SerializeField] private CellSpawner cellsSpawner;
    public CellSpawner CellsSpawner => cellsSpawner;
    [SerializeField] private CellsSwaps cellsSwaps;
    public CellsSwaps CellsSwaps => cellsSwaps;
    [SerializeField] private CellsShuffling cellsShuffling;
    public CellsShuffling CellsShuffling => cellsShuffling;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCellSpawner();
        LoadCellMovement();
        LoadCellsShuffle();
    }

    private void LoadCellsShuffle()
    {
        this.cellsShuffling = GetComponentInChildren<CellsShuffling>();
    }

    private void LoadCellMovement()
    {
        this.cellsSwaps = GetComponentInChildren<CellsSwaps>();
    }

    private void LoadCellSpawner()
    {
        this.cellsSpawner = GetComponentInChildren<CellSpawner>();
    }

    protected override void SetDontDestroyOnLoad()
    {
    }
}