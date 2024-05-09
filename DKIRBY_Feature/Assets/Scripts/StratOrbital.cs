using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// [Kirby, Declan]
/// Last updated [05/08/2024]
/// Deals with activation of orbital stratagem
/// </summary>
public class StratOrbital : Stratagem
{

    public GameObject orbitalPrefab;
    private void Awake()
    {
        //sets the combination for this stratagem
        this.keyCombination = new KeyCode[] { KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.W };
       
    }


    /// <summary>
    /// Finds the player location and spawns this above their head
    /// then begins the movement in the orbital animation script based on the stratballs location
    /// </summary>
    /// <param name="stratBallLocation"></param>
    public override void Activate(Vector3 stratBallLocation)
    {
       
        Vector3 spawnLocation = getPlayerLocation();
        spawnLocation.y += 15;
        GameObject newObject = Instantiate(orbitalPrefab, spawnLocation, transform.rotation);
        newObject.GetComponent<OrbitalAnimation>().targetLocation = stratBallLocation;
    }
}
