using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 12f;
    [SerializeField] float yRange = 10f;

    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float controlPitchFactor = -13f;

    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;
    void Start()
    {
        Debug.Log("French Bull Dog kiss lol a");
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
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Shooting");
        }
        else
        {
            Debug.Log("Don't print shooting");
        }
        
    }

    void processRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

       
        float yaw =  transform.localPosition.x * positionYawFactor;


        float roll = xThrow * controlRollFactor ;

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
