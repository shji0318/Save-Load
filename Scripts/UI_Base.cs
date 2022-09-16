using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] obj = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), obj);

        for (int i = 0; i < obj.Length; i++)
        {
            obj[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    public T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] obj = null;
        if (_objects.TryGetValue(typeof(T), out obj) == false)
            return null;

        return obj[index] as T;
    }
}
