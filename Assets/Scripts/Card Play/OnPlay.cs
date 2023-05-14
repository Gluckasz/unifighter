using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : MonoBehaviour
{
    private void OnEnable()
    {
        // Enable all scripts that take action after card play
        ConstantAttack constantAttackScript = GetComponent<ConstantAttack>();
        if (constantAttackScript != null )
        {
            constantAttackScript.enabled = true;
        }
        this.enabled = false;
    }
}