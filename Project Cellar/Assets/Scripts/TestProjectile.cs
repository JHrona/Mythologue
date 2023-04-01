using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.name != "Player")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
            collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage);
            Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Rock"))
            {
                return;
            }
        
        // Pokud narazíme na jakýkoliv jiný collider, zničíme projektil
         else
            {
                 Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        // Pokud narazíme na collider, který není hráč, zničíme projektil a způsobíme poškození nepříteli
        
    }   

}

