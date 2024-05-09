using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratSpawner : MonoBehaviour
{

    public GameObject airPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        Instantiate(airPrefab,transform.position,transform.rotation);
    }
}
