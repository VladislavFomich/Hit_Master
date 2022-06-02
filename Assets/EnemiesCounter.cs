using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    private int _killEnemy;
    public int KillEnemy { get => _killEnemy; }

    public void ResetCount()
    {
        _killEnemy = 0;
    }
    public void UpdateCount()
    {
        _killEnemy++;
    }

}
