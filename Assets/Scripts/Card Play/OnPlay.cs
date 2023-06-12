using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : MonoBehaviour
{
    private void OnEnable()
    {
        EnergyDrain energyDrainScript = GetComponent<EnergyDrain>();
        energyDrainScript.enabled = true;
        // Enable all scripts that take action after card play
        ConstantAttack constantAttackScript = GetComponent<ConstantAttack>();
        if (constantAttackScript != null )
        {
            constantAttackScript.enabled = true;
        }
        ConstantDefence constantDefenceScript = GetComponent<ConstantDefence>();
        if (constantDefenceScript != null )
        {
            constantDefenceScript.enabled = true;
        }
        DrawCards drawCardsScript = GetComponent<DrawCards>();
        if (drawCardsScript != null)
        {
            drawCardsScript.enabled = true;
        }
        GainEnergy gainEnergyScript = GetComponent<GainEnergy>();
        if (gainEnergyScript != null)
        {
            gainEnergyScript.enabled = true;
        }
        this.enabled = false;
    }
}
