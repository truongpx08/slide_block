using System.Collections;
using System.Collections.Generic;
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

    private void StartGame()
    {
        PlayGameObjects.Instance.GoTiles.TilesSpawner.Spawn(5, 5);
    }
}