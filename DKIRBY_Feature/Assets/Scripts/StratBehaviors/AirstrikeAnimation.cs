using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirstrikeAnimation : MonoBehaviour
{
    public Vector3 targetLocation;

    private Vector3 startingPos;

    

    // Start is called before the first frame update
    void Start()
    {
        startingPos = this.transform.position;
        
    }

    public float timeDuration = 1f;
    public Vector3 p01;

    public bool checkToCalculate = true;
    public bool moving = false;
    public float timeStart;
    /// <summary>
    /// Move the thing, allow the user to check the checkToCalculate box in the inspector
    /// to start our movement
    /// </summary>
    private void Update()
    {
        if (checkToCalculate)
        {
            checkToCalculate = false;

            //set the moving bool to true, and that will start the movement
            moving = true;
            timeStart = Time.time;
        }
        //now check to see if we need to move
        if (moving)
        {
            float u = (Time.time - timeStart) / timeDuration;

            //are we done moving (is u at 1(for us that means a u of 100%))
            if (u >= 1)
            {
                //make sure we don't go past 100% of our way from point 0 to point 1
                u = 1;

                //we made it to point 1, so we need to stop
                moving = false;
            }

            //use the standard linear interpolation formula
            p01 = (1 - u) * startingPos + u * targetLocation;

            this.transform.position = p01;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            Debug.Log("KABOOOM");
            Destroy(this.gameObject);
        }
    }
}
