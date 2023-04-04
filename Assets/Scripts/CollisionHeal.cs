using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    public int Heal = 20;
    public string CollisiomDamageTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CollisiomDamageTag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.SetHit(Heal);
            Destroy(gameObject);
        }
    }
}
