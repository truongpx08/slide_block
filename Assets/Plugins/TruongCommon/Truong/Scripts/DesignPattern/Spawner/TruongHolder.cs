using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// Contains Items
/// </summary>
public class TruongHolder : TruongGameObject
{
    [SerializeField] protected List<Transform> items;
    public List<Transform> Items => items;

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        items = new List<Transform>();
    }

    [Button]
    public void AddItem(Transform item)
    {
        EnableGo(item);
        item.parent = this.transform;
        items.Add(item);
    }

    [Button]
    public Transform GetAvailableItemForReuse(Transform obj)
    {
        foreach (var item in items.Where(item => item.name == obj.name && !item.gameObject.activeSelf))
        {
            EnableGo(item);
            return item;
        }

        return null;
    }
}