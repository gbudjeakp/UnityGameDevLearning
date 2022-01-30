using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathVfx;
    [SerializeField] int increaseBy = 20;
    [SerializeField] int enemyHitPoints = 4;


    ScoreBoard scoreBoard;
    GameObject parentGameObject;


    private void Start()
    {

        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRunTime");
        Addrigidbody();
    }

    private void Addrigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {


        if (enemyHitPoints < 1)
        {
            KillEnemy();
            ScoreCounter();
        }

    }

    private void ScoreCounter()
    {
        enemyHitPoints--;       
    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(increaseBy);
        GameObject vfx = Instantiate(enemyDeathVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}