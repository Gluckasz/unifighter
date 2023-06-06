using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class DrawCards : MonoBehaviour
{
    private GameObject deck;
    private GameObject discard;
    private GameObject hand;
    public int draw = 1;
    public int maxHandSizeAdded = 2;
    private void OnEnable()
    {
        deck = GameObject.FindGameObjectWithTag("Deck");
        discard = GameObject.FindGameObjectWithTag("DiscardPile");
        hand = GameObject.FindGameObjectWithTag("Hand");
        int maxHandSize = GameObject.FindGameObjectWithTag("EndTurnManager").GetComponent<EndTurnManager>().maxHandSize + maxHandSizeAdded;
        int drawCounter = 0;
        while (drawCounter < draw && hand.transform.childCount < maxHandSize)
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
            deck.transform.GetChild(0).SetParent(hand.transform);
            // When the draw size reached, stop getting cards out of deck
            drawCounter++;
        }
        this.enabled = false;
    }
}
