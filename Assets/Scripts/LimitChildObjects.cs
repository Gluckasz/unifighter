using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitChildObjects : MonoBehaviour
{
    public int maxElements = 7; // The maximum number of child objects allowed in the layout group

    private HorizontalLayoutGroup hlg; // Reference to the Horizontal Layout Group component

    private void Start()
    {
        hlg = GetComponent<HorizontalLayoutGroup>();
    }

    private void LateUpdate()
    {
        // If the number of child objects exceeds the maximum allowed, remove the excess objects
        if (hlg.transform.childCount > maxElements)
        {
            for (int i = hlg.transform.childCount - 1; i >= maxElements; i--)
            {
                Destroy(hlg.transform.GetChild(i).gameObject);
            }
        }
    }
}
