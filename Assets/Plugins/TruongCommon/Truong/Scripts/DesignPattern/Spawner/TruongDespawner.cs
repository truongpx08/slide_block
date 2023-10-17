using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class TruongDespawner : TruongMonoBehaviour
{
    [SerializeField] private TruongSpawner spawner;

    public Action<Transform> onDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawner();
    }

    private void LoadSpawner()
    {
        this.spawner = GetComponentInBro<TruongSpawner>();
    }

    [Button]
    public void DespawnDefaultObject()
    {
        var prefab = spawner.Prefabs.GetDefaultPrefab();
        DespawnObject(prefab);
    }

    [Button]
    public void DespawnObject(Transform obj)
    {
        if (obj == null) return;
        obj.gameObject.SetActive(false);
        onDespawn?.Invoke(obj);
    }


    [Button]
    public void DespawnAllObject()
    {
        spawner.Holder.Items.ForEach(DespawnObject);
    }
}