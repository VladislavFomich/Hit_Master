using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(BoxCollider))]
public class EnemieHealth : MonoBehaviour
{
    [SerializeField] private float _totalHealth = 100f;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private PlayerMove _playerMove;

    private BoxCollider _boxCollider;
    private Animator _animator;
    private float _health;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
        _health = _totalHealth;
        InitHealth();
    }

    public void ReduceHealth(float damage)
    {
        _health -= damage;
        InitHealth();
        if (_health <= 0f)
        {
            Die();
        }
    }
    private void InitHealth()
    {
        _healthSlider.value = _health / _totalHealth;
    }

    private void Die()
    {
        _playerMove.KillOnWayCount();
        _canvas.SetActive(false);
       _animator.enabled = false;
        _boxCollider.enabled = false;
    }

}
