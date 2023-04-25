using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;


    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public Slider healthBarSlider;

    public GameObject lootDrop;
    public GameObject player;
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;
    private float lastShotTime;

    private void Start()
    {
        health = maxHealth; 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
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
    }

    private void FixedUpdate()
    {
        if(isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        if(isInAttackRange && Time.time > lastShotTime + cooldown)
        {
            ShootPlayer();
            rb.velocity = Vector2.zero;
        }
    }
    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    private void EnemyAI()
    {
                anim.SetBool("IsMoving", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if(shouldRotate)
        {
            anim.SetFloat("horizontalMovement", dir.x);
            anim.SetFloat("verticalMovement", dir.y);
        }

        if (isInChaseRange)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

        if (isInAttackRange)
        {
            anim.SetBool("IsMoving", false);
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

}
