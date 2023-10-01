using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : TruongDragAbstract
{
    protected override void OnDirectionChanged(TruongDragDirection value)
    {
        PlayGameObjects.Instance.GoTiles.TilesSwaps.CalculateTileCanSwaps(value);
    }
}