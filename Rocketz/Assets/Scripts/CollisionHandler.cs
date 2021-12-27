using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        string comparator = other.gameObject.tag;
        switch (comparator)
        {
            case "Fuel":
                Debug.Log("Got more Fuel");
                break;
            case "Friendly":
                Debug.Log("On Launch Pad");
                break;
            case "Finish":
                nextLevel();
                break;
            default:
                respawner();
                break;
        }
    }

    void respawner()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void nextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }
}
