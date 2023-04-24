using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float yOffset = 45f;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private float yPos = 0;
    private bool isHovering = false;
    private RectTransform rectTransform;

    private void OnTransformParentChanged()
    {
        rectTransform = GetComponent<RectTransform>();
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
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
        LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalLayoutGroup.GetComponent<RectTransform>());
    }
}
