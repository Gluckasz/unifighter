using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 5;
    public int block = 0;
    public int maxHealth = 42;
    private void Awake()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (block - damage > 0)
        {
            // First deal damage to block
            block -= damage;
        }
        else if (health + block - damage > 0)
        {
            // If block exceeded, deal excess damage do health
            health -= damage - block;
            block = 0;
        }
        else
        {
            // Dies
            health = maxHealth;
        }
    }
    public void ChangeBlock(int blockChange)
    {
        block += blockChange;
    }
    public void ChangeHealth(int healthChange)
    {
        if (healthChange + health > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthChange;
        }
    }
}
