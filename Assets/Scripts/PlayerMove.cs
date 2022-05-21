using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private int[] _enemyOnWayCount;

    private int _currentPoint = 0;
    private bool _canRun = false;
    private bool _startTap = true;
    private int _killEnemy;
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && _startTap)
            {
                _startTap = false;
                Move();
            }
        }
        else if (_canRun)
        {
            Move();
        }
    }
    private void Move()
    {
        _agent.SetDestination(_wayPoints[_currentPoint].position);
        _animator.SetBool("IsRun", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        _currentPoint++;
        _killEnemy = 0;
        _canRun = false;
        if (_currentPoint == _wayPoints.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        _animator.SetBool("IsRun", false);
    }
    public void KillOnWayCount()
    {
        _killEnemy++;
        if (_killEnemy == _enemyOnWayCount[_currentPoint - 1])
        {
            _canRun = true;
        }
    }

}
