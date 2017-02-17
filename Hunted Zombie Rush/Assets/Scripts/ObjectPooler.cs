using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // makes a pool od objects to be reused
    public static ObjectPooler Current;
    [SerializeField] private int _pooledAmount = 20;
    [SerializeField] private GameObject _pooledObject;
    private List<GameObject> _pooledObjects;
    [SerializeField] private bool _willGrow = true;


    private void Awake()
    {
        Current = this;
    }

    // Use this for initialization
    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        for (var i = 0; i < _pooledAmount; i++)
        {
            var obj = Instantiate(_pooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        for (var i = 0; i < _pooledObjects.Count; i++)
            if (!_pooledObjects[i].activeInHierarchy)
                return _pooledObjects[i];

        if (_willGrow)
        {
            var obj = Instantiate(_pooledObject);
            // obj.SetActive(false);
            _pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}