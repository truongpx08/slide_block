using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inherit this class to get the event of the player dragging in one direction
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public abstract class TruongDragAbstract : TruongMonoBehaviour
{
    [SerializeField] private TruongDragDirection dragDirection;
    public TruongDragDirection DragDirection => dragDirection;
    private Vector2 dragStartPosition;
    private Vector2 dragEndPosition;
    private Vector2 dragDirectionPosition;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        SetDirection(TruongDragDirection.None);
    }

    private void OnMouseDown()
    {
        UpdateDragStartPosition();
    }

    private void OnMouseUp()
    {
        UpdateDragEndPosition();
        Calculate();
    }

    private void Calculate()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        this.dragDirectionPosition = dragEndPosition - dragStartPosition;

        if (dragDirectionPosition.y > 0 && Mathf.Abs(dragDirectionPosition.y) > Mathf.Abs(dragDirectionPosition.x))
        {
            SetDirection(TruongDragDirection.Top);
        }

        if (dragDirectionPosition.y < 0 && Mathf.Abs(dragDirectionPosition.y) > Mathf.Abs(dragDirectionPosition.x))
        {
            SetDirection(TruongDragDirection.Bottom);
        }

        if (dragDirectionPosition.x > 0 && Mathf.Abs(dragDirectionPosition.x) > Mathf.Abs(dragDirectionPosition.y))
        {
            SetDirection(TruongDragDirection.Right);
        }

        if (dragDirectionPosition.x < 0 && Mathf.Abs(dragDirectionPosition.x) > Mathf.Abs(dragDirectionPosition.y))
        {
            SetDirection(TruongDragDirection.Left);
        }
    }


    private void UpdateDragStartPosition()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        this.dragStartPosition = Input.mousePosition;
    }

    private void UpdateDragEndPosition()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        this.dragEndPosition = Input.mousePosition;
    }

    private void SetDirection(TruongDragDirection value)
    {
        this.dragDirection = value;
        OnDirectionChanged(value);
    }

    protected abstract void OnDirectionChanged(TruongDragDirection value);
}