using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class HornyStacks : MonoBehaviour
{
    private HealthManager enemyHealthManagerScript;
    private EndTurnManager endTurnManagerScript;
    public int hornyStack = 0;
    private void Awake()
    {
        endTurnManagerScript = GameObject.FindGameObjectWithTag("EndTurnManager").GetComponent<EndTurnManager>();
        enemyHealthManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthManager>();
    }
    private void OnEnable()
    {
        if (gameObject.GetComponent<ConstantAttack>() != null) 
        {
            hornyStack = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HornyStacks>().hornyStack;
            enemyHealthManagerScript.ChangeBlock(hornyStack);
        }
        if (gameObject.GetComponent<EnemyAttack>() != null )
        {
            hornyStack++;
        }
        if (hornyStack > 4)
        {
            hornyStack = 0;
            endTurnManagerScript.setEnergy = 1;
        }
        this.enabled = false;
    }
}
