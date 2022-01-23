using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem enemyDeathVfx;

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(enemyDeathVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
