using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : TruongMonoBehaviour
{
    [SerializeField] private Vector2 dragStartPosition;
    [SerializeField] private Vector2 dragEndPosition;
    [SerializeField] private Vector2 dragDirection;

    private void OnMouseDown()
    {
        UpdateDragStartPosition();
        Debug.Log("OnMouseDown");
    }

    private void OnMouseUp()
    {
        UpdateDragEndPosition();
        Calculate();
        Debug.Log("OnMouseUp");
    }

    private void Calculate()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        this.dragDirection = dragEndPosition - dragStartPosition;

        if (dragDirection.y > 0 && Mathf.Abs(dragDirection.y) > Mathf.Abs(dragDirection.x))
        {
            Debug.Log("Người chơi kéo lên trên");
        }

        if (dragDirection.y < 0 && Mathf.Abs(dragDirection.y) > Mathf.Abs(dragDirection.x))
        {
            Debug.Log("Người chơi kéo xuống dưới");
        }

        if (dragDirection.x > 0 && Mathf.Abs(dragDirection.x) > Mathf.Abs(dragDirection.y))
        {
            Debug.Log("Người chơi kéo sang phải");
        }

        if (dragDirection.x < 0 && Mathf.Abs(dragDirection.x) > Mathf.Abs(dragDirection.y))
        {
            Debug.Log("Người chơi kéo sang trái");
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
}