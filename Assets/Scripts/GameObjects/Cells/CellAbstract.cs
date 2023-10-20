using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellAbstract : TruongMonoBehaviour
{
    [SerializeField] protected SpriteRenderer model;
    [SerializeField] protected CellData data;
    public CellData Data => data;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    private void LoadModel()
    {
        this.model = this.transform.Find(TruongConstants.MODEL).GetComponent<SpriteRenderer>();
    }

    public void SetSizeModel(float cellSize)
    {
        this.model.size = new Vector2 { x = cellSize, y = cellSize };
    }

    public void SetData(CellData cellData)
    {
        this.data = cellData;
    }
}