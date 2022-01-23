using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] float delay = 2f;

    private void OnTriggerEnter(Collider other)
    {

        death();

    } 

    void death()
    {
        GetComponent<PlayerController>().enabled = false;
        Invoke("respawner", delay);
    }


    void respawner()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    

}
