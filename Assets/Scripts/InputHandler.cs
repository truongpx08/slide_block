using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : TruongDragAbstract
{
    protected override void OnDirectionChanged(TruongDragDirection value)
    {
        if (value == TruongDragDirection.None) return;
        PlayGameObjects.Instance.GoCells.CellsSwaps.Swapping(value);
    }
}