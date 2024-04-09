using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new AttackCard(0, "Strike", 1, 5, "Deal 5 to enemy"));
        cardList.Add(new AttackCard(1, "Strike", 1, 5, "Deal 5 to enemy"));
        cardList.Add(new AttackCard(2, "Strike", 1, 5, "Deal 5 to enemy"));
        cardList.Add(new AttackCard(3, "Strike", 1, 5, "Deal 5 to enemy"));
        cardList.Add(new AttackCard(4, "Strike", 1, 5, "Deal 5 to enemy"));
        cardList.Add(new SkillCard(5, "Block", 1, 5, "Add 5 block"));
        cardList.Add(new SkillCard(6, "Block", 1, 5, "Add 5 block"));
        cardList.Add(new SkillCard(7, "Block", 1, 5, "Add 5 block"));
        cardList.Add(new SkillCard(8, "Block", 1, 5, "Add 5 block"));
        cardList.Add(new SkillCard(9, "Block", 1, 5, "Add 5 block"));
        cardList.Add(new AttackCard(10, "Big Attack", 2, 12, "Deal 12 to enemy"));
        cardList.Add(new SkillCard(11, "Big Block", 2, 12, "Add 12 block"));
    }
}
