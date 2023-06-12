using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainEnergy : MonoBehaviour
{
    private EnergyManager energyManagerScript;
    public int energyGain = 2;
    private void Awake()
    {
        energyManagerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<EnergyManager>();
    }
    private void OnEnable()
    {
        energyManagerScript.ChangeEnergy(energyGain);
        this.enabled = false;
    }
}
