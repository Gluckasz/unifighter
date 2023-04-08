using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnlargeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.2f; // The factor by which to scale the object

    private bool isHovering = false;
    private Vector3 originalScale; // The original scale of the object
    private void Start()
    {
        originalScale = transform.localScale;
    }
    private void Update()
    {
        if (isHovering)
        {
            transform.localScale = originalScale * scaleFactor;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        transform.localScale = originalScale;
    }
}

