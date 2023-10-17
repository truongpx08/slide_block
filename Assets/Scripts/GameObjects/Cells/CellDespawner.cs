using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDespawner : TruongDespawner
{
    protected override void Start()
    {
        base.Start();
        this.onDespawn += transform1 => { Debug.Log("a"); };
    }
}