using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoint = 5;
    int currentHitPoints = 0;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHitPoints = hitPoint;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints < 1)
        {
           gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}