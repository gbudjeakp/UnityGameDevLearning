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
                Debug.Log("Landing Successful");
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
}
