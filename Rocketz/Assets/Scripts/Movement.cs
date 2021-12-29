using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Cached refrences for speed and readability
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] ParticleSystem leftThruster;
    [SerializeField] ParticleSystem rightThruster;
    [SerializeField] ParticleSystem rocketBooster;


    //Serialized variables for adjusting values
    [SerializeField] float rocketThrust = 1000f;
    [SerializeField] float rotationThrust = 200f;
    [SerializeField] AudioClip engineThruster;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            startThrusting();

        }
        else
        {
            audioSource.Stop();
            rocketBooster.Stop();
        }
    }

    private void startThrusting()
    {
        rb.AddRelativeForce(Vector3.up * rocketThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            rocketBooster.Play();
            audioSource.PlayOneShot(engineThruster);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotatingLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotatingRight();
        }
    }

    private void rotatingRight()
    {
        applyRotation(-rotationThrust);
        if (!rightThruster.isPlaying)
        {
            rightThruster.Play();
        }
        else
        {
            rightThruster.Stop();
        }
    }

    private void rotatingLeft()
    {
        applyRotation(rotationThrust);
        if (!leftThruster.isPlaying)
        {
            leftThruster.Play();
        }
        else
        {
            leftThruster.Stop();
        }
    }

    private void applyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //Frrezing rotation so we can manually move 
        transform.Rotate(Vector3.left * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //Unfreezing rotation so the physics system can manually take over
    }
}