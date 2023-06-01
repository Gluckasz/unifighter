using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveManager : MonoBehaviour
{
    public List<string> Moves = new List<string>();
    private string move;
    private EnemyAttack enemyAttack;
    private GameObject endTurnManager;
    private EndTurnManager endTurnManagerScript;

    private void Awake()
    {
        endTurnManager = GameObject.FindGameObjectWithTag("EndTurnManager");
        endTurnManagerScript = endTurnManager.GetComponent<EndTurnManager>();
        enemyAttack = GetComponent<EnemyAttack>();
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
        if (move == "Attack")
        {
            enemyAttack.enabled = true;
        }
    }

    private string SelectMove()
    {
        int randomIndex = UnityEngine.Random.Range(0, Moves.Count);
        string selectedMove = Moves[randomIndex];
        return selectedMove;
    }
}
