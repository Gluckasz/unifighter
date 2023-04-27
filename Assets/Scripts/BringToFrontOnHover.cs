using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BringToFrontOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private bool addedOne = false;
    private void OnTransformParentChanged()
    {       
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        horizontalLayoutGroup.enabled = false;
        if (transform.parent.childCount > transform.GetSiblingIndex() + 1)
        {
            transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
            addedOne = true;
        }
    }
    // If the card is clicked, don't move it then in SiblingIndex
    void OnMouseDown()
    {
        addedOne = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.parent.childCount > transform.GetSiblingIndex() + 1 || addedOne)
        {
            transform.SetSiblingIndex(transform.GetSiblingIndex() - 1);
            addedOne = false;
        }
        horizontalLayoutGroup.enabled = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalLayoutGroup.GetComponent<RectTransform>());
    }
}

