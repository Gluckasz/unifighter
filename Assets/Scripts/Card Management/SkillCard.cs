using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCard : Card
{
    public int cardBlock;

    public SkillCard(int id, string name, int cost, int block, string description) : base(id, name, cost, description)
    {
        cardBlock = block;
    }
}
