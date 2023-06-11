using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrain : MonoBehaviour
{
    public int energyCost = -1;
    private EnergyManager energyManagerScript;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        energyManagerScript = player.GetComponent<EnergyManager>();
    }
    private void OnEnable()
    {
        // Drain energy
        energyManagerScript.ChangeEnergy(energyCost);
        this.enabled = false;
    }
}
