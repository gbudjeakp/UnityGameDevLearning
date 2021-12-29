using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;
   
    [SerializeField] float delay = 1f;

    bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }

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
        isTransitioning = true;

        successParticles.Play();
        audioSource.Stop();

        audioSource.PlayOneShot(success);




        GetComponent<Movement>().enabled = false;
        Invoke("nextLevel", delay);
    }

    void startCrashSequence()
    {
        isTransitioning = true;
        crashParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);



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
