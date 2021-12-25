using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int bumped = 0;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("You've bumped into the Wall " + bumped + " times");
    }
}

