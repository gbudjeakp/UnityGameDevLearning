using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] float x = 0;
    [SerializeField] float y = 0f;
   [SerializeField] float z = 0f;
    void Start()
    {
      transform.Translate(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x, y, z);
    }
}
