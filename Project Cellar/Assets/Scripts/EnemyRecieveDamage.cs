using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRecieveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public GameObject lootDrop;

    void Start()
    {
        health = maxHealth;    
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
