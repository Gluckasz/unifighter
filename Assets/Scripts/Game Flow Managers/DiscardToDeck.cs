using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardToDeck: MonoBehaviour
{
    public GameObject discard;
    public GameObject deck;
    private void OnMouseDown()
    {
        int discardLen = discard.transform.childCount;
        for (int i = 0; i < discardLen; i++)
        {
            // If the deck size reached, stop getting cards out of discard
            discard.transform.GetChild(0).SetParent(deck.transform);
        }
    }
}
