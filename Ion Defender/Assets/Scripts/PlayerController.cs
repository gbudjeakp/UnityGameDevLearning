using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    // Start is called before the first frame update
    void Start()
    {

    }

     private void OnEnable() {
         movement.Enable();
     }

     private void OnDisable() {
         movement.Disable();
     }
    // Update is called once per frame
    void Update()
    {
          float horizontalThrow = movement.ReadValue<Vector2>().x;
          float verticalThrow = movement.ReadValue<Vector2>().y;

        // float horizontalThrow = Input.GetAxis("Horizontal");
        // float verticakThrow = Input.GetAxis("Vertical");
        Debug.Log(horizontalThrow);
        Debug.Log(verticalThrow);

    }
}
