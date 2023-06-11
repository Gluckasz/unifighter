using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int energy = 3;
    public int maxEnergy = 3;
    private void Awake()
    {
        energy = maxEnergy;
    }
    public void SetEnergy(int energySet)
    {
        energy = energySet;
    }
    public void ChangeEnergy(int energyGain)
    {
        energy += energyGain;
    }
}
