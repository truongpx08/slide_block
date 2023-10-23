using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
///  Inherit this function to ensure that there is only one instance of a class created.
///  You can access the unique object from anywhere in the program using the syntax "ClassName.Instance".
/// </summary>
public abstract class TruongSingleton<T> : TruongChild
{
    public static T Instance { get; private set; }

    protected override void SetVarToDefault()
    {
        base.SetVarToDefault();
        AddTruongInitialization();
    }

    private void AddTruongInitialization()
    {
        if (HasComponent<TruongInitialization>()) return;
        this.gameObject.AddComponent<TruongInitialization>();
    }

    /// <summary>
    /// Called from TruongInitialization 
    /// </summary>
    // [Button]
    public void InitializeSingleton()
    {
        Debug.Log("Init Singleton: " + this.name);
        SetInstance();
    }


    // [Button]
    private T DebugInstance()
    {
        return Instance;
    }

    // [Button]
    private void SetInstance()
    {
        var components = GetComponents<T>();
        LogException(components);
        if (components == null) return;
        Instance = components[0];
    }

    private void LogException(T[] components)
    {
        if (components == null)
        {
            Debug.LogError(
                $"Component inheriting from TruongSingleton not found.");
            return;
        }

        if (components.Length <= 1) return;
        Debug.LogError(
            $"There are more than one component inheriting from TruongSingleton.");
    }
}