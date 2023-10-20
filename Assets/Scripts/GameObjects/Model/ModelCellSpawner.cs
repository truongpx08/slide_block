using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCellSpawner : CellSpawnerAbstract
{
    protected override void SetPrefabNameInResource()
    {
        SetPrefabNameInResource("ModelCell");
    }

    protected override void SetSpacing()
    {
        SetSpacing(0);
    }

    protected override void Spawn()
    {
        var count = 0;
        for (int rowIndex = 0; rowIndex < this.CellsOnEdgeSquare; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < this.CellsOnEdgeSquare; columnIndex++)
            {
                var obj = SpawnDefaultObject();
                var cell = obj.GetComponent<ModelCell>();
                cell.SetData(new CellData()
                {
                    row = rowIndex,
                    column = columnIndex,
                });

                cell.SetSizeModel(this.cellSize);
                cell.SetSpriteModel(count);
                count++;
            }
        }
    }

    protected override void SetupSquareLayout()
    {
        this.squareLayout = Holder.GetComponent<TruongSquareLayout>();
        squareLayout.SetUp(Model.Instance.CellsPointEdgeSquare, this.CellsOnEdgeSquare, this.spacing);
    }
}