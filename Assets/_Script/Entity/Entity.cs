using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public abstract class Entity<T> : MonoBehaviour where T : Entity<T>
{
    private readonly Dictionary<Type, IEntityComponent<T>> componentDictionary = new();
    protected virtual void Awake()
    {
        var componentList =
            GetComponentsInChildren<IEntityComponent<T>>(true)
            .ToList();
        componentList.ForEach(x => InitializeEntityComponent(x));
    }
    private IEntityComponent<T> InitializeEntityComponent(IEntityComponent<T> component)
    {
        componentDictionary.Add(component.GetType(), component);
        if (component is IEntityComponentRequireInit<T> instance)
            instance.EntityComponentAwake(this as T);
        return component;
    }
    public ComponentType GetEntityComponent<ComponentType>() where ComponentType : Component, IEntityComponent<T>
    {
        if (componentDictionary.TryGetValue(typeof(ComponentType), out IEntityComponent<T> value))
            return value as ComponentType;
        Debug.LogError("[ERROR]can't find Entity_Component, reInitializing...");
        IEntityComponent<T> missingInstance = GetComponentInChildren<ComponentType>();
        //T missingInstance = GetComponentInChildren<T>(true);
        return InitializeEntityComponent(missingInstance) as ComponentType;
    }
}


