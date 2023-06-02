using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAndBlock : MonoBehaviour
{
    public int damage = 3;
    public int blockGain = 12;
    private PlayerHealthManager playerHealthScript;
    private EnemyHealthManager enemyHealthScript;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<PlayerHealthManager>();
        enemyHealthScript = this.GetComponent<EnemyHealthManager>();
    }
    private void OnEnable()
    {
        // Deal damage to the enemy
        enemyHealthScript.ChangeBlock(blockGain);
        playerHealthScript.TakeDamage(damage);
        this.enabled = false;
    }
}
