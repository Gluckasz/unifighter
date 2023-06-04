using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddToken : MonoBehaviour
{
    private EnemyMoveManager enemyMoveManagerScript;
    private void Awake()
    {
        enemyMoveManagerScript = this.GetComponent<EnemyMoveManager>();
    }
    private void OnEnable()
    {
        enemyMoveManagerScript.token = true;
        this.enabled = false;
    }
}
