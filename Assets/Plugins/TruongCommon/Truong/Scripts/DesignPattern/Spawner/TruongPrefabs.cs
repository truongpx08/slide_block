using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TruongPrefabs : TruongMonoBehaviour
{
    [SerializeField] protected string prefabsPath;
    [SerializeField] protected List<Transform> prefabs;

    public void SetPrefabPath(string value)
    {
        this.prefabsPath = value;
        LoadPrefabsInResource();
    }

    private void LoadPrefabsInResource()
    {
        prefabs = Resources.LoadAll<Transform>(prefabsPath).ToList();
        CheckNull(prefabs);
    }

    public Transform GetPrefabWithName(string prefabName)
    {
        return prefabs.Find(p => p.name == prefabName);
    }

    public Transform GetDefaultPrefab()
    {
        return prefabs[0];
    }
}