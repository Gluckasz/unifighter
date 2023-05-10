using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    private GameObject discardPile;
    public bool isDragging = false;
    private Vector3 offset;
    private RectTransform rectTransform;
    private RectTransform containerRectTransform;
    private Canvas canvas;
    private BringToFrontOnHover bringToFrontOnHover;
    private MoveOnHover moveOnHover;
    private HorizontalLayoutGroup horizontalLayoutGroup;

    private void OnTransformParentChanged()
    {
        if (transform.parent.gameObject.tag == "DiscardPile")
        {
            horizontalLayoutGroup.enabled = true;
            LayoutRebuilder.ForceRebuildLayoutImmediate(containerRectTransform);
        }
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
        if (horizontalLayoutGroup != null)
        {
            containerRectTransform = horizontalLayoutGroup.GetComponent<RectTransform>();
            horizontalLayoutGroup.enabled = true;
            LayoutRebuilder.ForceRebuildLayoutImmediate(containerRectTransform);
            discardPile = GameObject.FindGameObjectWithTag("DiscardPile");
            bringToFrontOnHover = GetComponent<BringToFrontOnHover>();
            moveOnHover = GetComponent<MoveOnHover>();
            rectTransform = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            bringToFrontOnHover.enabled = true;
            moveOnHover.enabled = true;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse down on: " + gameObject.name);
        // Make other scripts that interfere with this script inactive
        bringToFrontOnHover.enabled = false;
        moveOnHover.enabled = false;
        isDragging = true;
        offset = rectTransform.position - GetMousePosition();
        // Set this card to be on the first plane - also it will make sure that card is inserted as first after dropping it to hand
        int siblingCount = gameObject.transform.parent.childCount;
        transform.SetSiblingIndex(siblingCount);
        horizontalLayoutGroup.enabled = false;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = GetMousePosition() + offset;
            rectTransform.position = new Vector3(mousePosition.x, mousePosition.y, rectTransform.position.z);
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }
    void OnMouseUp()
    {
        Debug.Log("Mouse up on: " + gameObject.name);
        isDragging = false;
        if (horizontalLayoutGroup != null)
        {
            // If card dropped on hand object, just insert it back to hand
            if (IsMouseWithinContainerBounds())
            {
                horizontalLayoutGroup.enabled = true;
                LayoutRebuilder.ForceRebuildLayoutImmediate(containerRectTransform);
                bringToFrontOnHover.enabled = true;
                moveOnHover.enabled = true;
            }
            // If card dropped anywhere else, play it and insert it to discard pile
            else
            {
                // TODO Play a card script should be enabled here
                gameObject.transform.SetParent(discardPile.transform);
            }
        }
    }

    private bool IsMouseWithinContainerBounds()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return RectTransformUtility.RectangleContainsScreenPoint(containerRectTransform, mouseWorldPosition);
    }
}
