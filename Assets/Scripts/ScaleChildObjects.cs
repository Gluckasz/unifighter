using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleChildObjects : MonoBehaviour
{
    public float scale = 0.7f; // The scale factor to apply to new child objects

    private void OnTransformChildrenChanged()
    {
        HorizontalLayoutGroup hlg = GetComponent<HorizontalLayoutGroup>();
        for (int i = 0; i < hlg.transform.childCount; i++)
        {
            Transform child = hlg.transform.GetChild(i);
            child.localScale = new Vector3(scale, scale, scale);
        }
    }
}
