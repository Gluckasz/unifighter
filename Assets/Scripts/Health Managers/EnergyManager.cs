using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyManager : MonoBehaviour
{
    public int energy = 3;
    public int maxEnergy = 3;

    public Text energyText;
    public Text maxEnergyText;
    private void Awake()
    {
        energy = maxEnergy;
        energyText.text = "" + energy;
        maxEnergyText.text = "" + maxEnergy;
    }
    public void SetEnergy(int energySet)
    {
        energy = energySet;
        energyText.text = "" + energy;
    }
    public void ChangeEnergy(int energyGain)
    {
        energy += energyGain;
        energyText.text = "" + energy;
    }
}
