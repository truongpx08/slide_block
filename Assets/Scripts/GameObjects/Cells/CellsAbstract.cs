using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellsAbstract<T> : TruongSingleton<T>
{
    [SerializeField] private CellDespawner cellsDespawner;
    public CellDespawner CellsDespawner => cellsDespawner;
    [SerializeField] private Transform cellsPointEdgeSquare;
    public Transform CellsPointEdgeSquare => cellsPointEdgeSquare;

    protected override void LoadComponents()
    {
        base.LoadComponents();
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
}