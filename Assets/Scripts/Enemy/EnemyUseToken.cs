using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUseToken : MonoBehaviour
{
    public int damage = 12;
    private GameObject player;
    private PlayerHealthManager playerHealthScript;
    private EnemyMoveManager enemyMoveManagerScript;

    private void Awake()
    {
        enemyMoveManagerScript = this.GetComponent<EnemyMoveManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<PlayerHealthManager>();
    }
    private void OnEnable()
    {
        // Deal damage to the enemy
        playerHealthScript.TakeDamage(damage);
        enemyMoveManagerScript.token = false;
        this.enabled = false;
    }
}
