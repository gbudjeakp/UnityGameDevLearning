using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoint = 5;

    [Tooltip("Adds more health to enemy when they die")]
    [SerializeField] int difficultyRamp = 1;

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

        if(currentHitPoints <= 0)
        {
           gameObject.SetActive(false);
            enemy.RewardGold();
            hitPoint += difficultyRamp;
        }
    }
}
