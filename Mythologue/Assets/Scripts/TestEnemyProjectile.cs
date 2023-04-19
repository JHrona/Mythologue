using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage;
    private GameObject player;
    private Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Enemy")
        {
            if(collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    void Start()
     {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
           transform.rotation = Quaternion.Euler(0, 0, rot + 180);
     }
}
