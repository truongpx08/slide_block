using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : CellsAbstract<Cells>
{
    [SerializeField] private CellSpawner cellSpawner;
    public CellSpawner CellSpawner => cellSpawner;
    [SerializeField] private CellsSwaps cellsSwaps;
    public CellsSwaps CellsSwaps => cellsSwaps;
    [SerializeField] private CellsShuffling cellsShuffling;
    public CellsShuffling CellsShuffling => cellsShuffling;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCellMovement();
        LoadCellsShuffle();
        LoadCellSpawner();
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
        this.cellSpawner = GetComponentInChildren<CellSpawner>();
    }
}