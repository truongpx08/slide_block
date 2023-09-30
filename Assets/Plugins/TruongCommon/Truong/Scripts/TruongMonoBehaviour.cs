using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// Inheriting this class helps facilitate maintenance and expansion, enhancing flexibility in project development.   
/// </summary>
public abstract class TruongMonoBehaviour : MonoBehaviour
{
    private bool hasDragged;

    /// <summary>
    /// Auto load script component dragged into Inspector
    /// </summary>
    private void OnValidate()
    {
        if (hasDragged) return;
        hasDragged = true;
        Debug.Log("Script component dragged into Inspector.");
        CreateChildren();
    }

    protected virtual void Awake()
    {
        SetDefault();
    }

    protected virtual void OnEnable()
    {
        // For Override 
    }

    protected virtual void Start()
    {
        // For Override 
    }

    protected virtual void FixedUpdate()
    {
        // For Override 
    }

    protected virtual void Update()
    {
        // For Override 
    }

    protected virtual void LateUpdate()
    {
        // For Override 
    }

    protected virtual void OnDisable()
    {
        // For Override 
    }

    protected virtual void OnDestroy()
    {
        // For Override 
    }

    protected virtual void CreateChildren()
    {
    }

    /// <summary>
    /// Calling this function makes all variables and dependencies of self and children assigned values.
    /// </summary>
    [Button]
    protected void SetDefaultAll()
    {
        SetDefault();
        SetDefaultChild();
    }

    /// <summary>
    /// Renaming variables often leads to variables and dependencies being reset.
    /// Call this function in Awake to ensure that variables and dependencies are assigned values when entering the game.
    /// </summary>
    protected virtual void SetDefault()
    {
        CreateChildren();
        LoadComponents();
        SetVarToDefault();
    }

    /// <summary>
    /// Renaming variables often leads to variables being reset.
    /// Therefore, assign default values to variables in this function to initialize them quickly instead of re-entering them in the Unity editor.
    /// </summary>
    protected virtual void SetVarToDefault()
    {
        //For override
    }

    /// <summary>
    /// Renaming variables often leads to the loss of dependencies for components.
    /// Therefore, assign default values to components in this function to initialize them quickly instead of re-entering them in the Unity editor.
    /// </summary>
    protected virtual void LoadComponents()
    {
        //For override
    }

    /// <summary>
    /// Calling this function helps the children's variables and dependencies to be assigned values.
    /// </summary>
    protected void SetDefaultChild()
    {
        var child = GetComponentsInChildren<TruongMonoBehaviour>().ToList();
        child.ForEach(c => c.SetDefault());
    }

    protected T GetComponentInBro<T>()
    {
        return this.transform.parent.GetComponentInChildren<T>();
    }

    protected void CheckNull(object obj)
    {
        if (obj != null) return;
        Debug.LogError("object is null");
    }
}