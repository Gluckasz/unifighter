using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EndTurnManager : MonoBehaviour
{
    public GameObject deck;
    public GameObject discard;
    public GameObject hand;
    private void OnMouseDown()
    {
        Debug.Log("Mouse down on " + gameObject.name);
        // Transfer control to enemy and discard all remaining cards
        int handLen = hand.transform.childCount;
        for (int i = 0; i < handLen; i++)
        {
            hand.transform.GetChild(0).SetParent(discard.transform);
        }
        // Start a new turn
        int handCounter = 0;
        while (handCounter < 7)
        {
            if (deck.transform.childCount == 0)
            {
                int discardLen = discard.transform.childCount;
                // Check if there are cards in discard to insert to deck
                if (discardLen > 0)
                {
                    for (int j = 0; j < discardLen; j++)
                    {
                        // When the deck size reached, stop getting cards out of discard
                        discard.transform.GetChild(0).SetParent(deck.transform);
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
    }
}
