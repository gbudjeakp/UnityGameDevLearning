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
    [SerializeField] GameObject hitEffect;
    [SerializeField] float timeBetweenShots = .5f;
    bool canShoot = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        int ammoAmount = GetComponent<Ammo>().GetCurrentAmmo();
        if (ammoAmount > 0)
        {
            playMuzzleFlash();
            ProcessRayCast();
            GetComponent<Ammo>().ReduceCurrentAmmo();
        }
        else
        {
            Debug.Log("No Ammo");
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot=true;
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
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
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
    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}