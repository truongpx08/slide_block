using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TruongPrefabs : TruongMonoBehaviour
{
    [SerializeField] private string prefabName;
    [SerializeField] protected string prefabPath;
    [SerializeField] protected List<Transform> prefabs;

    public void SetPathWithPrefabName(string value)
    {
        this.prefabName = value;
        this.prefabPath = TruongPath.GetPrefabInResourcePath(this.prefabName);
        LoadPrefabsInResource();
    }

    private void LoadPrefabsInResource()
    {
        prefabs = Resources.LoadAll<Transform>(prefabPath).ToList();
        CheckNull(prefabs);
    }

    public Transform GetPrefabWithName(string value)
    {
        return prefabs.Find(p => p.name == value);
    }

    public Transform GetDefaultPrefab()
    {
        return prefabs[0];
    }
}