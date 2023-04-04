using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HealthObj;
    public int MaxHealth;

    public void TakeHit(int damage)
    {
        HealthObj -= damage;
        if (HealthObj <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetHit(int bonushealth)
    {
        HealthObj += bonushealth;
        if (HealthObj > MaxHealth)
        {
            HealthObj = MaxHealth;
        }
    }

}