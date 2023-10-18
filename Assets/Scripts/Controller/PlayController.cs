using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

public class PlayController : TruongSingleton<PlayController>
{
    protected override void SetDontDestroyOnLoad()
    {
        SetDontDestroyOnLoad(false);
    }

    [Button]
    private void StartGame(int level = 1)
    {
        Cells.Instance.CellsDespawner.DespawnAllObject();
        Cells.Instance.CellSpawner.SpawnWithLevel(level);
        Cells.Instance.CellsShuffling.Shuffling();
    }

    [Button]
    Transform GetParent()
    {
        return this.transform.parent;
    }

    [Button]
    void SetParent()
    {
        this.transform.SetAsFirstSibling();
    }
}