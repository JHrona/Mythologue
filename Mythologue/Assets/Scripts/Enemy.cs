using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private new Rigidbody2D rigidbody2D;
    public GameObject healthBar;
    public Slider healthBarSlider;

    public GameObject lootDrop;
    public GameObject player;
        public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;
        protected GameObject target;
          private float lastShotTime;



    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        health = maxHealth; 
        Target();

    }




    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        healthBarSlider.value = CalculateHealthPercentage();
        health -= damage;
        CheckDeath();
    }
    
    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverheal()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    
    private void CheckDeath()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }

    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }

    private void Update()
    {

        if(player != null)
        {
        EnemyAI();

        }
        if(health <= 0)
        {
            healthBar.SetActive(false);
        }
                if(player != null)
    {
                float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 5f && Time.time > lastShotTime + cooldown)
    
        {
        ShootPlayer();
        }   
    }
    }
    
    // function to move the enemy towards the player
    public void MoveTowardsPlayer()
    {
        if (player != null)
        {
            rigidbody2D.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime);
            }
    }
    // create enemy ai to move towards the player when the player is within a certain radius of the enemy

    
    // create a function to not shoot at the player if the enemy is moving towards the player
public void EnemyAI()
{
    float distance = Vector3.Distance(transform.position, player.transform.position);
    if (distance >= 5f)
    {
        MoveTowardsPlayer();
    }
}

  private void ShootPlayer()
    {
        
        if (target != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = target.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            lastShotTime = Time.time; // Ulož poslední čas střelby
        }
    }
        private void Target()
    {
        if(player != null)
        {
        target = FindObjectOfType<Movement>().gameObject;
        }
        return;

    }


}
