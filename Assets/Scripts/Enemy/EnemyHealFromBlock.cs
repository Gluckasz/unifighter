using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealFromBlock : MonoBehaviour
{
    private EnemyHealthManager enemyHealthScript;

    private void Awake()
    {
        enemyHealthScript = this.GetComponent<EnemyHealthManager>();
    }
    private void OnEnable()
    {
        // Deal damage to the enemy
        enemyHealthScript.ChangeHealth(enemyHealthScript.block);
        this.enabled = false;
    }
}
