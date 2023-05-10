using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckToHand : MonoBehaviour
{
    public GameObject deck;
    public GameObject hand;
    private void OnMouseDown()
    {
        for (int i = 0; i < hand.transform.childCount; i++)
        {
            GameObject.Destroy(hand.transform.GetChild(i).gameObject);
        }
        int deckLen = deck.transform.childCount;
        for (int i = 0; i < deckLen; i++)
        {
            // If the hand size reached, stop getting cards out of deck
            if (i >= 6)
            {
                break;
            }
            deck.transform.GetChild(0).SetParent(hand.transform);
        }
    }
}
