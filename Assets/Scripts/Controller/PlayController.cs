using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
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
        Cells.Instance.CellsSpawner.SpawnWithLevel(level);
        Cells.Instance.CellsShuffling.Shuffling();
    }
}