using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class TruongPath
{
    public static string GetPrefabInResourcePath(string name)
    {
        return Path.Combine(TruongFolderName.PREFABS, name);
    }

    public static string GetSpriteInResourcePath(string name)
    {
        return Path.Combine(TruongFolderName.SPRITES, name);
    }
}