using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent),typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private SceneManage _sceneManage;
    [SerializeField] private EnemiesCounter _enemiesCounter;

    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private int[] _enemyOnWayCount;

    private int _currentPoint = 0;
    private bool _canRun = false;
    private bool _startTap = true;

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
        _enemiesCounter.ResetCount();
        _canRun = false;
        if (_currentPoint == _wayPoints.Length)
        {
            _sceneManage.ReloadScene();
        }
        _animator.SetBool("IsRun", false);
    }
    public void KillOnWayCount()
    {
        _enemiesCounter.UpdateCount();
        if (_enemiesCounter.KillEnemy == _enemyOnWayCount[_currentPoint - 1])
        {
            _canRun = true;
        }
    }

}
