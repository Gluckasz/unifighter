using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantAttack : MonoBehaviour
{
    public int damage = 1;
    private GameObject enemy;
    private EnemyHealthManager enemyHealthScript;
    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealthScript = enemy.GetComponent<EnemyHealthManager>();
    }
    private void OnEnable()
    {
        // Deal damage to the enemy
        enemyHealthScript.TakeDamage(damage);
        this.enabled = false;
    }
}
