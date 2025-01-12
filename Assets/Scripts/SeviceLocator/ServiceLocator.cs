using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void RegisterService<TInterface, TImplementation>(TImplementation service) where TImplementation : TInterface
    {
        var interfaceType = typeof(TInterface);
        var implementationType = typeof(TImplementation);

        if (_services.ContainsKey(interfaceType) || _services.ContainsKey(implementationType))
        {
            Debug.LogWarning($"Service of type {interfaceType} or {implementationType} is already registered.");
            return;
        }

        _services[interfaceType] = service;
        _services[implementationType] = service;
    }

    public static T GetService<T>()
    {
        var type = typeof(T);

        if (_services.ContainsKey(type))
        {
            return (T)_services[type];
        }

        foreach (var kvp in _services)
        {
            if (type.IsAssignableFrom(kvp.Key))
            {
                return (T)kvp.Value;
            }
        }

        Debug.LogError($"Service of type {type} is not registered.");
        throw new Exception($"Service of type {type} is not registered.");
    }

    public static void UnregisterService<TInterface>()
    {
        var type = typeof(TInterface);
        if (_services.ContainsKey(type))
        {
            _services.Remove(type);
            Debug.Log($"Service of type {type} has been unregistered.");
        }
        else
        {
            Debug.LogWarning($"Service of type {type} is not registered, so it cannot be unregistered.");
        }
    }

    public static void ClearService()
    {
        _services.Clear();
    }
}
