using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargetFinder : MonoBehaviour
{
    [SerializeField] ParticleSystem particlepProjectiles;
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        for(int i = 0; i < enemies.Length; i++)
        {
            float targetDistance = Vector3.Distance(transform.position, enemies[i].transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemies[i].transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emission = particlepProjectiles.emission;
        emission.enabled = isActive;
    }
}
