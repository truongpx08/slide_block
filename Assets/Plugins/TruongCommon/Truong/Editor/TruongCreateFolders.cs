using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TruongCreateFolders : MonoBehaviour
{
    private enum AssetType
    {
        Scenes, // Contains all game Scenes
        Scripts, // Contains C# source code and your scripts
        Prefabs, // Contains Prefabs - objects created for reuse
        // Materials, // Contains materials (Materials)
        // Textures, // Contains images and textures
        // Audio, // Contains all sound and music
        // Animations, // Contains Animation Clips and Animation Controllers
        // UI, // Contains user interface components
        Resources, // Contains unpredictable resources, use with caution
        // Editor, // Contains Editor-related code (does not work in runtime)
        Plugins, // Contains plugins and external libraries
        // StreamingAssets, // Contains resources accessed via code (like text files)
        // Docs, // Contains project documentation (if any)
        // Tests, // Contains tests and test cases
        // ThirdParty, // Contains external resources not available through Unity Package Manager
        // ScenesMeta, // Stores metadata of Scenes (not manually edited)
        // ProjectSettings, // Stores project settings (not manually edited)
        // Other, // Contains another asset
        // Fonts, // Contains font files
        // Shaders, // Contains shader files
        Sprites, // Contains sprites
    }

    [MenuItem("Truong/Create 2D Folders")]
    private static void Create2DFolders()
    {
        //GetAllType
        AssetType[] assetTypes = (AssetType[])Enum.GetValues(typeof(AssetType));
        var list = assetTypes.ToList();
        list.ForEach(item =>
        {
            if (HasFolder(item.ToString())) return;

            AssetDatabase.CreateFolder("Assets", item.ToString());
            Debug.Log("Has created folder " + item.ToString());
        });

        bool HasFolder(string folderName)
        {
            string folderPath = Path.Combine(Application.dataPath, folderName);
            return Directory.Exists(folderPath);
        }
    }
}