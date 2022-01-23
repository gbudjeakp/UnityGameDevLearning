using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("Controls how far left or right a player can go")]
    [SerializeField] float xRange = 12f;
    [Tooltip("Control how far up or down a player can move")]
    [SerializeField] float yRange = 10f;
    [Tooltip("Controls The Lasers array")]
    [SerializeField] GameObject[] lasers;

    [Header("Movement Settings")]
    [Tooltip("controls the position pitch factor")]
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float controlPitchFactor = -13f;
    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        processTranslate();
        processRotation();
        processFiring();

    }


    void processFiring()
    {
        string fire = "Fire1";

        if (Input.GetButton(fire))
        {
            setLasersActive(true);
        }
        else
        {
            setLasersActive(false);
        }

    }

    void setLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }


    void processRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;


        float yaw = transform.localPosition.x * positionYawFactor;


        float roll = xThrow * controlRollFactor;

        //Euler pronounced aouiler
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void processTranslate()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3
        (clampedXPos,
         clampedYPos,
        transform.localPosition.z);
    }
}
