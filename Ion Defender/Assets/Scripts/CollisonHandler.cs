using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [Tooltip("Controls hw long it takes for scene to reload")]
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] ParticleSystem enemyDeath;

    private void OnTriggerEnter(Collider other)
    {

        Death();

    }

    void Death()
    {
        deathExplosion.Play();
        GetComponent<PlayerController>().enabled = false;
        Invoke("Respawner", delay);

        GetComponent<MeshRenderer>().enabled = false;
    }


    void Respawner()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }



}
