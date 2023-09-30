using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TruongCreateFolders : MonoBehaviour
{
    [MenuItem("Truong/Create 2D Folders")]
    private static void Create2DFolders()
    {
        List<string> list = new List<string>
        {
            TruongFolderName.SCENES,
            TruongFolderName.SCRIPTS,
            TruongFolderName.PREFABS,
            TruongFolderName.RESOURCES,
            TruongFolderName.PLUGINS,
            TruongFolderName.SPRITES,
        };
        list.ForEach(item =>
        {
            if (HasFolder(item)) return;

            AssetDatabase.CreateFolder(TruongFolderName.ASSETS, item);
            Log(item);
        });

        CreatePrefabsInResources();
    }

    private static void CreatePrefabsInResources()
    {
        string resourcesPath = Path.Combine(TruongFolderName.ASSETS, TruongFolderName.RESOURCES);
        string prefabFolderPath = Path.Combine(resourcesPath, TruongFolderName.PREFABS);
        if (AssetDatabase.IsValidFolder(prefabFolderPath)) return;
        AssetDatabase.CreateFolder(resourcesPath, TruongFolderName.PREFABS);
        Log(TruongFolderName.PREFABS);
    }

    private static bool HasFolder(string folderName)
    {
        string folderPath = Path.Combine(Application.dataPath, folderName);
        return Directory.Exists(folderPath);
    }

    private static void Log(string item)
    {
        Debug.Log("Has created folder " + item);
    }
}