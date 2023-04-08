using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float yOffset = 45f;

    private float yPos = 0;
    private bool isHovering = false;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (isHovering)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, yPos + yOffset);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        yPos = rectTransform.anchoredPosition.y;
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
