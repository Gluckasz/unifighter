using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int block;
    public int maxHealth;
    public Text healthText;
    public Image healthBar;

    public Text blockText;

    float lerpSpeed;
    private void Awake()
    {
        healthText.text = "Health: " + health;
        health = maxHealth;
    }
    private void Update()
    {   
        healthText.text = "Health: " + health;

        blockText.text = "Block: " + block;

        lerpSpeed = 3f * Time.deltaTime;

        healthBarFiller();
        colorChange();
    }
    void healthBarFiller()
    {
        // Changing the fill amout of the hp bar
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (float)health / (float)maxHealth, lerpSpeed);
    }

    void colorChange()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (float)health / (float)maxHealth);
        if(block > 0)
        {
            healthColor = Color.gray;
        }
        healthBar.color = healthColor;
    }
    public void TakeDamage(int damage)
    {
        if (block - damage > 0)
        {
            // First deal damage to block
            block -= damage;
        }
        else if (health + block - damage > 0)
        {
            // If block exceeded, deal excess damage do health
            health -= damage - block;
            block = 0;
        }
        else
        {
            // Dies
            health = maxHealth;
        }
       
    }
    public void ChangeBlock(int blockChange)
    {
        block += blockChange;
    }
    public void ChangeHealth(int healthChange)
    {
        if (healthChange + health > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthChange;
        }
    }
}
