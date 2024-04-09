using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    public int cardAttack;

    public AttackCard(int id, string name, int cost, int attack, string description) : base(id, name, cost, description)
    {
        cardAttack = attack;
    }
}
