using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");
        float xOffset = .02f;

        float newXPos = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3
        (newXPos,
        transform.localPosition.y,
        transform.localPosition.z);


    }
}
