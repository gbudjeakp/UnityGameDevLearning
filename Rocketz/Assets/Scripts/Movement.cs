using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Cached refrences for speed and readability
    Rigidbody rb;
    AudioSource audioSource;


    //Serialized variables 
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
            rb.AddRelativeForce(Vector3.up * rocketThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engineThruster);
            }

        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            applyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            applyRotation(-rotationThrust);
        }
    }

    private void applyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //Frrezing rotation so we can manually move 
        transform.Rotate(Vector3.left * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //Unfreezing rotation so the physics system can manually take over
    }
}