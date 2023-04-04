using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private int Damage = 20;
    public string collisiomDamageTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisiomDamageTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeHit(Damage);
        }
    }
}
