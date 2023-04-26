using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class TestProjectile : MonoBehaviour
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
         else
            {
                 Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        
    }   

} */

public class TestProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.name != "Player")
        {
            if (collision.GetComponent<Enemy1>() != null)
            {
            collision.GetComponent<Enemy1>().DealDamage(damage);
            }
            else if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Player"))
            {
                return;
            }
            Destroy(gameObject);
        }
        
    }   

}


