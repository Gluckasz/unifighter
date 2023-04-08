using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BringToFrontOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private bool addedOne = false;
    private void Start()
    {       
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        horizontalLayoutGroup.enabled = false;
        Debug.Log(transform.parent.childCount);
        if (transform.parent.childCount > transform.GetSiblingIndex() + 1)
        {
            transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
            addedOne = true;
        }
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

