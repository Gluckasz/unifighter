using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : MonoBehaviour
{
    private void OnEnable()
    {
        // Enable all scripts that take action after card play
        this.enabled = false;
    }
}
