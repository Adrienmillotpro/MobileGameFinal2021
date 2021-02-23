using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;

    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }
}
