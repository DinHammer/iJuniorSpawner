using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton pattern
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static bool isQuitting { get; set; }
    private static bool isExist { get; set; }

    private static T instance;
    private static readonly object objLock = new object();

    public static T Instance
    {
        get
        {
            if (isQuitting)
            {
                return null;
            }

            lock (objLock)
            {
                if (isExist)
                {
                    return instance;
                }

                GameObject go = new GameObject(typeof(T).Name);
                instance = go.AddComponent<T>();
                isExist = true;
                return instance;
            }
        }
    }

    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            isExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this as T)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private void OnApplicationQuit()
    {
        isQuitting = true;
        isExist = false;
    }
}