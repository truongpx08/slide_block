using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : TruongDragAbstract
{
    protected override void OnDirectionChanged(TruongDirection value)
    {
        if (value == TruongDirection.None) return;
        PlayGameObjects.Instance.GoCells.CellsSwaps.SwapsWithInput(value);
        GameOver.Instance.Check();
    }
}