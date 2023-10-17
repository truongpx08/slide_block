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
    public TruongPrefabs Prefabs => prefabs;

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
    public Transform SpawnDefaultObject()
    {
        var prefab = prefabs.GetDefaultPrefab();
        return SpawnObjectWithPrefab(prefab);
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
        TruongUtils.SetNameObject(newObj, prefab.name);
        AddItemToHolder(newObj);
        ResetTransformObj(newObj);
        TruongUtils.AddIdToObject(prefab.GetInstanceID(), newObj);
        return newObj;
    }

    private void AddItemToHolder(Transform newObj)
    {
        holder.AddItem(newObj);
    }
}