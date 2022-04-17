using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        playMuzzleFlash();
        ProcessRayCast();
    }

    private void playMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit:" + hit.transform.name);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            //Add visual effect
            //method to decrease enemy health
            if (target == null)
            {
                return;
            }

            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }
}
