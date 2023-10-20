using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : TruongSingleton<Cells>
{
    [SerializeField] private CellSpawner cellSpawner;
    public CellSpawner CellSpawner => cellSpawner;
    [SerializeField] private CellsSwaps cellsSwaps;
    public CellsSwaps CellsSwaps => cellsSwaps;
    [SerializeField] private CellsShuffling cellsShuffling;
    public CellsShuffling CellsShuffling => cellsShuffling;
    [SerializeField] private CellDespawner cellsDespawner;
    public CellDespawner CellsDespawner => cellsDespawner;
    [SerializeField] private Transform cellsPointEdgeSquare;
    public Transform CellsPointEdgeSquare => cellsPointEdgeSquare;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCellSpawner();
        LoadCellMovement();
        LoadCellsShuffle();
        LoadCellDespawner();
        LoadCellPointEdgeSquare();
    }

    private void LoadCellPointEdgeSquare()
    {
        this.cellsPointEdgeSquare = this.transform.Find("PointEdgeSquare");
    }

    private void LoadCellDespawner()
    {
        this.cellsDespawner = GetComponentInChildren<CellDespawner>();
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

    protected override void SetDontDestroyOnLoad()
    {
    }
}