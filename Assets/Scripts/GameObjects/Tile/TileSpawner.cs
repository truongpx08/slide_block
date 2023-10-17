using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : TruongSpawner
{
    protected override void SetPrefabNameInResource()
    {
        SetPrefabNameInResource(TruongPrefabName.TILE);
    }
}