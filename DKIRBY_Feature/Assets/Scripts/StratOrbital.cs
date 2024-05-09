using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StratOrbital : Stratagem
{

    public GameObject orbitalPrefab;
    private void Awake()
    {
        this.keyCombination = new KeyCode[] { KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.W };
        Debug.Log("Orbital Combination Set");
    }



    public override void Activate(Vector3 stratBallLocation)
    {
        Debug.Log("Orbital Incoming!!!");
        Vector3 spawnLocation = getPlayerLocation();
        spawnLocation.y += 15;
        GameObject newObject = Instantiate(orbitalPrefab, spawnLocation, transform.rotation);
        newObject.GetComponent<OrbitalAnimation>().targetLocation = stratBallLocation;
    }
}
