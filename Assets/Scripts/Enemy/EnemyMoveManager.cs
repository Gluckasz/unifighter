using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveManager : MonoBehaviour
{
    public List<string> Moves = new List<string>();
    private string move;
    private EnemyAttack enemyAttackScript;
    private GameObject endTurnManager;
    private EndTurnManager endTurnManagerScript;
    private EnemyAttackAndBlock enemyAttackAndBlockScript;

    private void Awake()
    {
        endTurnManager = GameObject.FindGameObjectWithTag("EndTurnManager");
        endTurnManagerScript = endTurnManager.GetComponent<EndTurnManager>();
        enemyAttackScript = GetComponent<EnemyAttack>();
        enemyAttackAndBlockScript = GetComponent<EnemyAttackAndBlock>();
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
                enemyAttackScript.enabled = true;
                break;
            case "Attack and block":
                enemyAttackAndBlockScript.enabled = true;
                break;
        }
    }

    private string SelectMove()
    {
        int randomIndex = UnityEngine.Random.Range(0, Moves.Count);
        string selectedMove = Moves[randomIndex];
        return selectedMove;
    }
}
