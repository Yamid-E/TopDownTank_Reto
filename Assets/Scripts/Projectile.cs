using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionPrefab;

   void OnCollisionEnter(Collision collision)
    {
    ContactPoint contact = collision.contacts[0];

    Instantiate(
        explosionPrefab,
        contact.point,
        Quaternion.LookRotation(contact.normal)
    );

    if (collision.gameObject.CompareTag("PlayerTank"))
    {
        collision.gameObject.GetComponent<TankHealth>().takeDamage(20);
    }

    if (collision.gameObject.CompareTag("EnemyTank"))
    {
        collision.gameObject.GetComponent<EnemyTankHealth>().takeDamage(20);
    }

    
    Destroy(gameObject);
    }
}
