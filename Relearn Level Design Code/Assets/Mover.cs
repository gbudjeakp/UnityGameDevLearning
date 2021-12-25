using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] int moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
     Greeter();
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }

    //Testing Methods
    void Greeter()
    {
        Debug.Log("Welcome to Kubaz.");
        Debug.Log("Move your player with AWSD");
        Debug.Log("Walls are dangerous");
    }

}
