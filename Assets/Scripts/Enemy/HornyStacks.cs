using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class HornyStacks : MonoBehaviour
{
    private HealthManager enemyHealthManagerScript;
    private EndTurnManager endTurnManagerScript;
    private GameObject player;
    private Transform playerTransform;
    public int hornyStack = 0;
    private void Awake()
    {
        endTurnManagerScript = GameObject.FindGameObjectWithTag("EndTurnManager").GetComponent<EndTurnManager>();
        enemyHealthManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
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
            for (int i = 0; i < playerTransform.childCount; i++)
            {
                Transform childTransform = playerTransform.GetChild(i);
                if (childTransform.gameObject.tag == "hornStack" && !childTransform.gameObject.activeSelf)
                {
                    childTransform.gameObject.SetActive(true);
                    break;
                }
            }
            hornyStack++;
        }
        if (hornyStack > 4)
        {
            for (int i = 0; i < playerTransform.childCount; i++)
            {
                Transform childTransform = playerTransform.GetChild(i);
                if (childTransform.gameObject.tag == "hornStack")
                {
                    childTransform.gameObject.SetActive(false);
                }
            }
            hornyStack = 0;
            endTurnManagerScript.setEnergy = 1;
        }
        this.enabled = false;
    }
}
