using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class TruongInitialization : TruongMonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        InitializeSingleton();
    }

    // [Button]
    private void InitializeSingleton()
    {
        // Iterate over all the components attached to the current game object and its children
        foreach (Component item in GetComponents<Component>())
        {
            // Check if the component is a subclass of TruongSingleton
            var baseType = item.GetType().BaseType;
            if (baseType == null) continue;
            if (!baseType.ToString().Contains("TruongSingleton")) continue;

            // Get the Initialize() method of the base class TruongSingleton using reflection
            MethodInfo m = baseType.GetMethod("Initialize");
            if (m == null) continue;

            // Invoke the Initialize() method
            m.Invoke(item, null);
        }
    }
}