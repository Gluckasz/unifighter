using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantAttack : MonoBehaviour
{
    public int damage = 1;
    private void OnEnable()
    {
        // Deal damage to the enemy
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyHealthManager enemyHealthScript = enemy.GetComponent<EnemyHealthManager>();
        enemyHealthScript.TakeDamage(damage);
        this.enabled = false;
    }
}
