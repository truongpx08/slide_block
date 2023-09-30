using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Component = UnityEngine.Component;
using Random = UnityEngine.Random;

public abstract class TruongSpawner : TruongChild
{
    [TitleGroup("Spawner")]
    [SerializeField] private TruongHolder holder;
    public TruongHolder Holder => holder;
    [SerializeField] private TruongPrefabs prefabs;

    protected override void CreateChildren()
    {
        base.CreateChildren();
        CreateChild(TruongConstants.HOLDER)?.AddComponent<TruongHolder>();
        CreateChild(TruongConstants.PREFABS)?.AddComponent<TruongPrefabs>();
    }

    protected override void LoadComponents()
    {
        LoadPrefabs();
        LoadContainer();
        SetPrefabNameInResource();
    }

    private void LoadContainer()
    {
        holder = GetComponentInChildren<TruongHolder>();
    }

    private void LoadPrefabs()
    {
        prefabs = GetComponentInChildren<TruongPrefabs>();
    }

    protected abstract void SetPrefabNameInResource();

    protected void SetPrefabNameInResource(string prefabName)
    {
        prefabs.SetPathWithPrefabName(prefabName);
    }

    [Button]
    protected Transform SpawnObject(string prefabName)
    {
        var prefab = prefabs.GetPrefabWithName(prefabName);
        return SpawnObjectWithPrefab(prefab);
    }

    [Button]
    protected Transform SpawnDefaultObject()
    {
        var prefab = prefabs.GetDefaultPrefab();
        return SpawnObjectWithPrefab(prefab);
    }

    [Button]
    protected void DespawnObject(Transform obj)
    {
        if (obj == null) return;
        obj.gameObject.SetActive(false);
        OnDespawn(obj);
    }

    [Button]
    protected void DespawnAllObject()
    {
        holder.Items.ForEach(DespawnObject);
    }

    private Transform SpawnObjectWithPrefab(Transform prefab)
    {
        if (prefab == null)
        {
            Debug.LogError($"No prefab found");
            return null;
        }

        var result = Holder.GetAvailableItemForReuse(prefab);
        return result == null ? InstantiateNewObject(prefab) : result;
    }

    private Transform InstantiateNewObject(Transform prefab)
    {
        Transform newObj = Instantiate(prefab);
        newObj.name = prefab.name;
        holder.AddItem(newObj);
        ResetTransformObj(newObj);
        return newObj;
    }

    protected virtual void OnDespawn(Transform obj)
    {
        //For override
    }
}