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

    protected override void Start()
    {
        base.Start();
        StartGame();
    }

    [Button]
    private void StartGame()
    {
        PlayGameObjects.Instance.GoCells.CellsSpawner.Spawn(5, 5);
        Cells.Instance.CellsShuffling.Shuffling();
    }
}