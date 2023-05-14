using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckToHand : MonoBehaviour
{
    public GameObject deck;
    public GameObject hand;
    public GameObject discard;
    private void OnMouseDown()
    {
        int handLen = hand.transform.childCount;
        for (int i = 0; i < handLen; i++)
        {
            hand.transform.GetChild(0).SetParent(discard.transform);
        }
        int deckLen = deck.transform.childCount;
        for (int i = 0; i < deckLen; i++)
        {
            // If the hand size reached, stop getting cards out of deck
            if (i >= 7)
            {
                break;
            }
            deck.transform.GetChild(0).SetParent(hand.transform);
        }
    }
}
