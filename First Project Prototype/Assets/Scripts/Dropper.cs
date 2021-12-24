using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    new MeshRenderer renderer;
    Rigidbody dropping;
    [SerializeField] float time = 3f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        dropping = GetComponent<Rigidbody>();
        renderer.enabled = false;
        dropping.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time)
        {
            renderer.enabled = true;
            dropping.useGravity = true;
        }
    }
}
