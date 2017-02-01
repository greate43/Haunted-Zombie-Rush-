using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    // makes a pool od objects to be reused
    public static ObjectPooler Current;
    [SerializeField] private GameObject _pooledObject;
    [SerializeField] private bool _willGrow = true;
    [SerializeField] private int _pooledAmount = 20;
    private List<GameObject> _pooledObjects;


    void Awake()
    {
        Current = this;
    }

    // Use this for initialization
    void Start()
    {
        _pooledObjects = new List<GameObject>();
        for (int i = 0; i < _pooledAmount; i++)
        {
            GameObject obj = Instantiate(_pooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        if (_willGrow)
        {
            GameObject obj = Instantiate(_pooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}