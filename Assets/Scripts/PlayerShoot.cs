using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletPool))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointTransform;
    [SerializeField] private float _bulletSpeed;

    private BulletPool _bulletPool;
    private Camera _camera;
    private bool _canShoot = false;

    private void Start()
    {
        _camera = Camera.main;
        _bulletPool = GetComponent<BulletPool>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (_canShoot)
                {
                    Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
                    GameObject bullet = _bulletPool.Instantiate(_spawnPointTransform.position, Quaternion.LookRotation(ray.direction));
                    Vector3 direction = ray.direction.normalized;
                    bullet.GetComponent<Rigidbody>().velocity = direction * _bulletSpeed;
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        _canShoot = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _canShoot = false;   
    }
}