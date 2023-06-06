using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantDefence : MonoBehaviour
{
    public int blockGain = 1;
    private GameObject player;
    private HealthManager playerHealthScript;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<HealthManager>();
    }
    private void OnEnable()
    {
        // Deal damage to the enemy
        playerHealthScript.ChangeBlock(blockGain);
        this.enabled = false;
    }
}