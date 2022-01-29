using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [Tooltip("Controls how long it takes for scene to reload")]
    [SerializeField] float delay = 2f;
    [SerializeField] ParticleSystem deathExplosion;

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
