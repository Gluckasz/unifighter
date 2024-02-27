using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int MAX_HP = 100; // maximal deck size
}

public class Player
{
    // All atributes of the player
    private int maxHealth; // maximum HP, it will be set at the start of the game, migth be changed with some events/cards
    private int currentHealth; // current HP, it cannot rise above maxHealth, whenever it drops below 0 the player dies and game ends
    private int currentBlock; // current block, it is being depleted before currentHealth while taking damage, it cannot be negative, uncapped until balancing

    public Player()
    {
        maxHealth = Constants.MAX_HP;
        currentHealth = maxHealth;
        currentBlock = 0;
    }

    // Getters
    public int getMaxHealth()
    {
        return maxHealth;
    }
    public int getCurrentHealth()
    {
        return currentHealth;
    }
    public int getCurrentBlock()
    {
        return currentBlock;
    }

    // Setters
    public void setMaxHealth(int value)
    {
        maxHealth = value;
    }
    public void setCurrentHealth(int value)
    {
        currentHealth = value;
    }
    public void setCurrentBlock(int value)
    {
        currentBlock = value;
    }

}
