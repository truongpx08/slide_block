using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameStart : TruongSingleton<GameStart>
{
    protected override void Start()
    {
        base.Start();
        StartGame();
    }

    [Button]
    private void StartGame(int level = 1)
    {
        Cells.Instance.CellsDespawner.DespawnAllObject();
        Cells.Instance.CellSpawner.SpawnWithLevel(level);
        Model.Instance.CellsDespawner.DespawnAllObject();
        Model.Instance.CellSpawner.SpawnWithLevel(level);
        Cells.Instance.CellsShuffling.Shuffling();
    }
}