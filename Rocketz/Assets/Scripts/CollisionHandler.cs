using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip success;
    [SerializeField] float delay = 1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        string comparator = other.gameObject.tag;
        switch (comparator)
        {
            case "Friendly":
                Debug.Log("On Launch Pad");
                break;
            case "Finish":
                startSuccessSequence();
                break;
            default:
                startCrashSequence();
                break;
        }
    }

    void startSuccessSequence()
    {

        // Add SFX upon success
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(success);
            Debug.Log("Sound");
        }
        else
        {
            audioSource.Stop();
        }
        GetComponent<Movement>().enabled = false;
        Invoke("nextLevel", delay);
    }

    void startCrashSequence()
    {

        // Add SFX upon crash
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(crashSound);
        }
        else
        {
            audioSource.Stop();
        }

        //Add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("respawner", delay);
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
