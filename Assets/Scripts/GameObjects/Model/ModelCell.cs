using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCell : CellAbstract
{
    public void SetSpriteModel(int count)
    {
        this.model.sprite = Cells.Instance.CellSpawner.Sprites[count];
    }
}