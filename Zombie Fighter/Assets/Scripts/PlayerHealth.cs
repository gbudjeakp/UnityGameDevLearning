using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

    public void PlayerDeath(float damage)
    {
        playerHealth -= damage;

        if(playerHealth <= 0)
        {
            //Call handle Death here 
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
