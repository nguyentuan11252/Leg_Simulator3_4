using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Ins { get => instance; }
    [SerializeField] private bool needDontDestroy = false;
    protected virtual void Awake()
    {
        instance = (T)this;
        if (needDontDestroy) DontDestroyOnLoad(gameObject);
    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
