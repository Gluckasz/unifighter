using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveManager : MonoBehaviour
{
    public List<string> Moves = new List<string>();
    public bool token = false;
    public string move;

    private EnemyAttack enemyAttackScript;
    private GameObject endTurnManager;
    private HealthManager enemyHealthManagerScript;
    private EndTurnManager endTurnManagerScript;
    private EnemyAttackAndBlock enemyAttackAndBlockScript;
    private EnemyHealFromBlock enemyHealFromBlockScript;
    private EnemyAddToken enemyAddTokenScript;
    private EnemyUseToken enemyUseTokenScript;
    private HornyStacks hornyStacksScript;
    private void Awake()
    {
        endTurnManager = GameObject.FindGameObjectWithTag("EndTurnManager");
        endTurnManagerScript = endTurnManager.GetComponent<EndTurnManager>();
        enemyHealthManagerScript = GetComponent<HealthManager>();
        enemyAttackScript = GetComponent<EnemyAttack>();
        enemyAttackAndBlockScript = GetComponent<EnemyAttackAndBlock>();
        enemyHealFromBlockScript = GetComponent<EnemyHealFromBlock>();
        enemyAddTokenScript = GetComponent<EnemyAddToken>();
        enemyUseTokenScript = GetComponent<EnemyUseToken>();
        hornyStacksScript = GetComponent<HornyStacks>();
    }
    private void Start()
    {
        move = SelectMove();
    }
    public void EnemyTurn()
    {
        EnemyMove(move);
        move = SelectMove();
        endTurnManagerScript.NewTurn();
    }

    private void EnemyMove(string move)
    {
        switch (move)
        {
            case "Attack":
                Debug.Log(gameObject.name + " Attack");
                hornyStacksScript.enabled = true;
                enemyAttackScript.enabled = true;
                break;
            case "Attack and block":
                Debug.Log(gameObject.name + " Attack and block");
                hornyStacksScript.enabled = true;
                enemyAttackAndBlockScript.enabled = true;
                break;
            case "Heal from block":
                Debug.Log(gameObject.name + " Heal from block");
                enemyHealFromBlockScript.enabled = true;
                break;
            case "Add token":
                Debug.Log(gameObject.name + " Adding token");
                enemyAddTokenScript.enabled = true;
                break;
            case "Use token":
                Debug.Log(gameObject.name + " Using token");
                hornyStacksScript.enabled = true;
                enemyUseTokenScript.enabled = true;
                break;
        }
    }

    private string SelectMove()
    {
        string selectedMove;
        if (enemyHealthManagerScript.health == enemyHealthManagerScript.maxHealth || enemyHealthManagerScript.block == 0)
        {
            // Don't randomly select moves with self heal if enemy fully healed
            Moves.Remove("Heal from block");
            int randomIndex = UnityEngine.Random.Range(0, Moves.Count);
            selectedMove = Moves[randomIndex];
            Moves.Add("Heal from block");
        }
        else
        {
            int randomIndex = UnityEngine.Random.Range(0, Moves.Count);
            selectedMove = Moves[randomIndex];
        }
        if (token)
        {
            return "Use token";
        }
        return selectedMove;
    }
}
