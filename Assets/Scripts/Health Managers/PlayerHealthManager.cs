using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int health = 5;
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            // Take damage
            health -= damage;
        }
        else
        {
            // Enemy dies
            health = 5;
        }
    }
}
