using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSignWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSignWave + 1f) / 2f;

        Vector3 offSet = movementVector * movementFactor;
        transform.position = startPosition + offSet;

    }
}
