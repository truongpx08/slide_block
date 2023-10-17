using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameOver : TruongSingleton<GameOver>
{
    [SerializeField] private bool isGameOver;

    protected override void SetDontDestroyOnLoad()
    {
    }

    [Button]
    public void Check()
    {
        this.isGameOver = true;
        Cells.Instance.CellSpawner.GetCells().ForEach(c =>
        {
            if (c.Data.column != c.Tile.Data.column
                || c.Data.row != c.Tile.Data.row)
                this.isGameOver = false;
        });
        OverGame();
    }

    [Button]
    private void OverGame()
    {
        Log();
    }

    private void Log()
    {
        if (!this.isGameOver) return;
        Debug.LogError("Game Over");
    }
}