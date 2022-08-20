using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    //Creae a public method which rduces hitpoints by the amount of damage

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("death");
    }
}
