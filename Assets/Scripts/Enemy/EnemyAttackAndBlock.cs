using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAndBlock : MonoBehaviour
{
    public int damage = 3;
    public int blockGain = 12;
    private HealthManager playerHealthScript;
    private HealthManager enemyHealthScript;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<HealthManager>();
        enemyHealthScript = this.GetComponent<HealthManager>();
    }
    private void OnEnable()
    {
        // Deal damage to the enemy and gain block
        playerHealthScript.TakeDamage(damage);
        enemyHealthScript.ChangeBlock(blockGain);
        this.enabled = false;
    }
}
