using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    [SerializeField] bool isPlacable;
    public bool IsPlacable
    {get { return isPlacable; }}

 
    private void OnMouseDown()
    {

        if (isPlacable)
        {
            Vector3 position = transform.position;
            Instantiate(towerPrefab, position, Quaternion.identity);
            isPlacable = false;
        }

    }
}
