using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
   [SerializeField] private GameObject _bullet;
   [SerializeField] private Transform _poolTransform;
   [SerializeField] private int _amount = 0;
   [SerializeField] private bool _populateOnStart = true;
   [SerializeField] private bool _growOverAmount = true;


    private List<GameObject> _pool = new List<GameObject>();

    void Start()
    {
        if (_populateOnStart && _bullet != null && _amount > 0)
        {
            for (int i = 0; i < _amount; i++)
            {
                var instance = Instantiate(_bullet);
                instance.transform.parent = _poolTransform;
                instance.SetActive(false);
                _pool.Add(instance);
            }
        }
    }

    public GameObject Instantiate(Vector3 position, Quaternion rotation)
    {
        foreach (var item in _pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = position;
                item.transform.rotation = rotation;
                item.SetActive(true);
                return item;
            }
        }

        if (_growOverAmount)
        {
            var instance = (GameObject)Instantiate(_bullet, position, rotation);
            _pool.Add(instance);
            return instance;
        }

        return null;
    }
}
