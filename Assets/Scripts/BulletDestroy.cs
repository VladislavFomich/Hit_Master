using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletDestroy : MonoBehaviour
{
    [SerializeField] private float _damage;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        EnemieHealth enemieHealth = collision.transform.GetComponent<EnemieHealth>();
        if (enemieHealth != null)
        {
            enemieHealth.ReduceHealth(_damage);
        }
        _rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
