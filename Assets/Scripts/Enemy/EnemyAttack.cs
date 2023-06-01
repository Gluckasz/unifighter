using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;
    private PlayerHealthManager playerHealthScript;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<PlayerHealthManager>();
    }
    private void OnEnable()
    {
        // Deal damage to the enemy
        playerHealthScript.TakeDamage(damage);
        this.enabled = false;
    }
}
