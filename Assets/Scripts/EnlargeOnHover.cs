using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnlargeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float newScale = 0.7f;
    public float oldScale = 0.34f;
    private bool isHovering = false;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private void Update()
    {
        if (isHovering)
        {
            transform.localScale = new Vector3(newScale, newScale, newScale);
            horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        transform.localScale = new Vector3(oldScale, oldScale, oldScale);
        LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalLayoutGroup.GetComponent<RectTransform>());
    }
}

