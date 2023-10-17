using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDespawner : TruongDespawner
{
    protected override void OnDisable()
    {
        base.OnDisable();
        DespawnAllObject();
    }
}
