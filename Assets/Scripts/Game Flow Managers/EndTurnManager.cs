using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EndTurnManager : MonoBehaviour
{
    public int maxHandSize = 3;
    public int setEnergy = 3;
    public GameObject deck;
    public GameObject discard;
    public GameObject hand;
    private GameObject enemy;
    private GameObject player;
    private EnemyMoveManager enemyMoveManagerScript;
    private EnergyManager energyManagerScript;
    private bool enemyMoveDone = true;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyMoveManagerScript = enemy.GetComponent<EnemyMoveManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        energyManagerScript = player.GetComponent<EnergyManager>();
        NewTurn();
    }
    private void OnMouseDown()
    {
        if (enemyMoveDone)
        {
            Debug.Log("Mouse down on " + gameObject.name);
            // Transfer control to enemy and discard all remaining cards
            int handLen = hand.transform.childCount;
            for (int i = 0; i < handLen; i++)
            {
                hand.transform.GetChild(0).SetParent(discard.transform);
            }
            enemyMoveDone = false;
            enemyMoveManagerScript.EnemyTurn();
            enemyMoveDone = true;
        }
    }
    public void NewTurn()
    {
        // Start a new turn
        int handCounter = 0;
        while (handCounter < maxHandSize)
        {
            if (deck.transform.childCount == 0)
            {
                int discardLen = discard.transform.childCount;
                // Check if there are cards in discard to insert to deck
                if (discardLen > 0)
                {
                    for (int j = 0; j < discardLen; j++)
                    {
                        int randomNumber = Random.Range(0, discard.transform.childCount - 1);
                        // When the deck size reached, stop getting cards out of discard
                        discard.transform.GetChild(randomNumber).SetParent(deck.transform);
                    }
                }
                // If there are no cards to insert to deck, just stop putting cards in deck
                else
                {
                    break;
                }

            }
            // When the hand size reached, stop getting cards out of deck
            deck.transform.GetChild(0).SetParent(hand.transform);
            handCounter++;
        }
        energyManagerScript.SetEnergy(setEnergy);
        setEnergy = energyManagerScript.maxEnergy;
    }
}
