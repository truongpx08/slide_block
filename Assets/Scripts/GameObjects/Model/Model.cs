using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : CellsAbstract<Model>
{
    [SerializeField] private ModelCellSpawner cellSpawner;
    public ModelCellSpawner CellSpawner => cellSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCellSpawner();
    }

    private void LoadCellSpawner()
    {
        this.cellSpawner = GetComponentInChildren<ModelCellSpawner>();
    }
}