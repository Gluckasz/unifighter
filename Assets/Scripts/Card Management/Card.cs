using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
    public int cardID;
    public string cardName;
    public int cardCost;    
    public string cardDescription;

    public Card(int id, string name, int cost, string description)
    {
        cardID = id;
        cardName = name;
        cardCost = cost;
        cardDescription = description;
    }

}
