using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealFromBlock : MonoBehaviour
{
    private HealthManager enemyHealthScript;

    private void Awake()
    {
        enemyHealthScript = this.GetComponent<HealthManager>();
    }
    private void OnEnable()
    {
        enemyHealthScript.ChangeHealth(enemyHealthScript.block);
        this.enabled = false;
    }
}
