using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StratAirStrike : Stratagem
{
    public GameObject airstrikePrefab;

    
    private void Awake()
    {
        this.keyCombination = new KeyCode[] {KeyCode.W, KeyCode.W , KeyCode.W , KeyCode.W };
        Debug.Log("Airstrike Combination Set");
    }
    


    public override void Activate(Vector3 stratBallLocation)
    {
        
            Debug.Log("Air-Strike!!!");
        Vector3 spawnLocation = getPlayerLocation();
        spawnLocation.y += 30;
        GameObject newObject = Instantiate(airstrikePrefab, spawnLocation, transform.rotation);
        newObject.GetComponent<AirstrikeAnimation>().targetLocation = stratBallLocation;





    }
    
}
