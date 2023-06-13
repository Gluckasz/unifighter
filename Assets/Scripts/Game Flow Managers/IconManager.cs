using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    public Sprite attack;
    public Sprite attackAndBlock;
    public Sprite healFromBlock;
    public Sprite addToken;
    public Sprite useToken;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeIcon(string currentIcon)
    {
        switch (currentIcon)
        {
            case "Attack":
                spriteRenderer.sprite = attack;
                break;
            case "Attack and block":
                spriteRenderer.sprite = attackAndBlock;
                break;
            case "Heal from block":
                spriteRenderer.sprite = healFromBlock;
                break;
            case "Add token":
                spriteRenderer.sprite = addToken;
                break;
            case "Use token":
                spriteRenderer.sprite = useToken;
                break;

        }
    }
}
