using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    // Start is called before the first frame update
    void Start()
    {
     Printinstructions();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void Printinstructions(){
     Debug.Log("Welcome to the game");
     Debug.Log("Move using A,W,S and D to move the player");
     Debug.Log("Dont hit the walls");
    }

    void movePlayer(){
          // Code here controls our movement for the player 
        float xValue = Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed ;
        float zValue =  Input.GetAxis("Vertical")* Time.deltaTime * moveSpeed;

        transform.Translate(xValue, 0, zValue);
    }
}
