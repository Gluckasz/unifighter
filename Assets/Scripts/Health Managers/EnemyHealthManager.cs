using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health = 5;
    public int block = 0;
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
            // Enemy dies
            health = 5;
        }
    }
    public void ChangeBlock(int blockChange)
    {
        block += blockChange;
    }

}
