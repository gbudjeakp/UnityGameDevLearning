using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int deathReward = 25;
    [SerializeField] int nodeathPenalty = 25;
    BankAccount bank;
    void Start()
    {
        bank = FindObjectOfType<BankAccount>();
    }

    public void RewardGold()
    {   
        if(bank == null) { return; }
        bank.Deposit(deathReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(nodeathPenalty);
    }

}
