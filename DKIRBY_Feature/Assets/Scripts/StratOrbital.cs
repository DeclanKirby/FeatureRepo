using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratOrbital : Stratagem
{
    private void Awake()
    {
        this.keyCombination = new KeyCode[] { KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.W };
        Debug.Log("Orbital Combination Set");
    }



    protected override void Activate()
    {
        Debug.Log("Orbital Incoming!!!");
    }
}
