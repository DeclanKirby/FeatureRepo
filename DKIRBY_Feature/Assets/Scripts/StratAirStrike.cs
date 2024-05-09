using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// [Kirby, Declan]
/// Last updated [05/08/2024]
/// Deals with activation of airstrike prefab
/// </summary>
public class StratAirStrike : Stratagem
{
    public GameObject airstrikePrefab;

    
    private void Awake()
    {
        //sets combination
        this.keyCombination = new KeyCode[] {KeyCode.W, KeyCode.W , KeyCode.W , KeyCode.W };
        
    }
    
    /// <summary>
    /// Finds the player location and spawns this above their head
    /// then begins the movement in the airstrike animation script based on the stratballs location
    /// </summary>
    /// <param name="stratBallLocation"></param>
    public override void Activate(Vector3 stratBallLocation)
    {                
        Vector3 spawnLocation = getPlayerLocation();
        spawnLocation.y += 30;
        GameObject newObject = Instantiate(airstrikePrefab, spawnLocation, transform.rotation);
        newObject.GetComponent<AirstrikeAnimation>().targetLocation = stratBallLocation;
    }
    
}
