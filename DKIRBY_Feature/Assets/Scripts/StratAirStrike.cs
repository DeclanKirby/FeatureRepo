using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StratAirStrike : Stratagem
{



    private void Awake()
    {
        this.keyCombination = new KeyCode[] {KeyCode.W, KeyCode.W , KeyCode.W , KeyCode.W };
        Debug.Log("Airstrike Combination Set");
    }

    

    protected override void Activate()
    {
        Debug.Log("Air-Strike!!!");
        //turn on strat ball
        
    }
    
}
